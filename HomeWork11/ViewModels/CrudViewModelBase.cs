using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Popups;
using HomeWork11.Commands;
using HomeWork11.Models;
using HomeWork11.Models.Stewardess;
using HomeWork11.Services;
using HomeWork11.Tools;

namespace HomeWork11.ViewModels
{
    public abstract class CrudViewModelBase<T, T1> : INotifyPropertyChanged where T : Entity where T1 : class, new()
    {
        protected readonly WebApiEntityService<T, T1> WebApiEntityService;
        private T _selectedEntity;
        private T1 _createEntity;
        private bool _createMode;
        private bool _isLoaded;

        public bool CreateMode
        {
            get { return _createMode;}
            set
            {
                if (_createMode != value)
                {
                    SelectedEntity = null;
                    _createMode = value;
                    OnPropertyChanged(nameof(CreateMode));
                }
            }
        }

        public T SelectedEntity
        {
            get { return _selectedEntity; }
            set
            {
                if (_selectedEntity != value)
                {
                    CreateMode = false;
                    _selectedEntity = value;
                    OnPropertyChanged(nameof(SelectedEntity));
                }
            }
        }

        public T1 CreateEntity
        {
            get { return _createEntity; }
            set
            {
                if (_createEntity != value)
                {
                    _createEntity = value;
                    OnPropertyChanged(nameof(CreateEntity));
                }
            }
        }

        public bool IsLoaded
        {
            get { return _isLoaded; }
            set
            {
                if (_isLoaded != value)
                {
                    _isLoaded = value;
                    OnPropertyChanged(nameof(IsLoaded));
                }
            }
        }

        public ObservableCollection<T> Entities { get; set; }

        public AsyncCommandBase DeleteCommand { get; }
        public AsyncCommandBase UpdateCommand { get; }
        public AsyncCommandBase CreateCommand { get; }
        public Command CreateModeCommand { get; }

        protected void UpdateItemInCollection(T item, ObservableCollection<T> collection = null)
        {
            collection = collection ?? Entities;
            var itemInCollection = collection.SingleOrDefault(x => x.Id == item.Id);
            int index = collection.IndexOf(itemInCollection);
            collection[index] = item;
        }

        protected CrudViewModelBase(string entityEndpoint)
        {
            DeleteCommand = new AsyncCommandBase(Delete);
            UpdateCommand = new AsyncCommandBase(Update);
            CreateCommand = new AsyncCommandBase(Create);
            CreateModeCommand = new Command(CreateCommandMethod);
            CreateEntity = new T1();
            Entities = new ObservableCollection<T>();
            WebApiEntityService = new WebApiEntityService<T, T1>(entityEndpoint);
            Initialization = Initialize();
        }

        private void CreateCommandMethod()
        {
            CreateMode = true;
        }

        public async Task Initialize()
        {
            try
            {
                await InitializeEntities();
                await InitializeData();
                IsLoaded = true;
            }
            catch (Exception ex)
            {
                var dialog = new MessageDialog($"Could not initialize content. \r\nReason: {ex.Message}",
                    "Something went wrong");
                await dialog.ShowAsync();
            }
        }

        protected virtual async Task InitializeData()
        {
            await Task.Delay(100);
        }

        private async Task InitializeEntities()
        {
            var entities = await WebApiEntityService.GetAll();
            foreach (var entity in entities)
            {
                Entities.Add(entity);
            }

            await Task.Delay(100);
        }

        private async Task Delete(object entityIdObj)
        {
            try
            {
                var entityId = (int)entityIdObj;
                var result = await WebApiEntityService.Delete(entityId);
                if (result)
                {
                    Entities.Remove(Entities.SingleOrDefault(x => x.Id == entityId));
                }
            }
            catch (AggregateException ex)
            {
                MessageDialog error = new MessageDialog($"Could not create the entity. Exception occured: \r\n{ex.Message}.", "Something went wrong!");
                await error.ShowAsync();
            }
        }

        protected async Task Update(object entityUpdateObject)
        {
            var entityToUpdate = (T)entityUpdateObject;
            var result = await WebApiEntityService.Update(entityToUpdate.Id, ConvertToUpdateObject(entityToUpdate));
            if (result)
            {
                UpdateItemInCollection(entityToUpdate);
                SelectedEntity = entityToUpdate;
            }
        }

        protected abstract T1 ConvertToUpdateObject(T entity);

        private async Task Create()
        {
            try
            {
                var createdEntity = await WebApiEntityService.Create(CreateEntity);
                if (createdEntity != null)
                {
                    Entities.Add(createdEntity);
                    CreateEntity = new T1();
                }
            }
            catch (AggregateException ex)
            {
                MessageDialog error = new MessageDialog($"Could not create the entity. Exception occured: \r\n{ex.Message}.", "Something went wrong!");
                await error.ShowAsync();
            }
        }
        
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        #endregion

        public Task Initialization { get; protected set; }
    }
}