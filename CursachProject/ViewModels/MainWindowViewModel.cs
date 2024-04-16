using CursachProject.Entites;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace CursachProject.ViewModels
{
    public class MainWindowViewModel : ReactiveObject
    {
        private ObservableCollection<Person> persons;
        private Person selectedPerson;

        public ObservableCollection<Person> Persons
        {
            get => persons;
            set => this.RaiseAndSetIfChanged(ref persons, value);
        }

        public Person SelectedPerson
        {
            get => selectedPerson;
            set => this.RaiseAndSetIfChanged(ref selectedPerson, value);
        }

        public ReactiveCommand<Unit, Unit> AddClientCommand { get; }
        public ReactiveCommand<Unit, Unit> AddMembershipCommand { get; }

        public MainWindowViewModel()
        {
            Persons = new ObservableCollection<Person>();

            AddClientCommand = ReactiveCommand.Create(AddClient);
            AddMembershipCommand = ReactiveCommand.Create(AddMembership);
        }

        private void AddClient()
        {
            Persons.Add(new Person { FullName = "Новый клиент", ContactInformation = "Новая контактная информация" });
        }

        private void AddMembership()
        {
            if (SelectedPerson != null)
            {
                SelectedPerson.Memberships.Add(new Membership
                {
                    Id = (int)Guid.NewGuid().ToByteArray()[0],
                    PersonId = SelectedPerson.Id, 
                    Person = SelectedPerson,
                    MemberName = "NewMember"
                });
            }
        }
    }
}