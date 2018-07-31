using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.Media.Core;
using HomeWork11.Commands;
using HomeWork11.Models.Stewardess;
using HomeWork11.Services;
using HomeWork11.Tools;

namespace HomeWork11.ViewModels
{
    public class StewardessViewModel : CrudViewModelBase<Stewardess, EditableStewardessFields>
    {
        public StewardessViewModel() : base ("stewardesses")
        {
            CreateEntity.BirthDate = DateTime.Now.AddYears(-20);
        }

        protected override EditableStewardessFields ConvertToUpdateObject(Stewardess entity)
        {
            return new EditableStewardessFields
            {
                BirthDate = entity.BirthDate,
                SecondName = entity.SecondName,
                FirstName = entity.FirstName
            };
        }
    }
}