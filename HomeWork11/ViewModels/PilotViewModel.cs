using System;
using System.Threading.Tasks;
using HomeWork11.Models.Pilot;

namespace HomeWork11.ViewModels
{
    public class PilotViewModel : CrudViewModelBase<Pilot, EditablePilotFields>
    {
        public PilotViewModel() : base("pilots")
        {
            CreateEntity.BirthDate = DateTime.Now.AddYears(-30);
        }

        protected override EditablePilotFields ConvertToUpdateObject(Pilot entity)
        {
            return new EditablePilotFields
            {
                FirstName = entity.FirstName,
                SecondName = entity.SecondName,
                BirthDate = entity.BirthDate,
                Experience = entity.Experience
            };
        }
    }
}