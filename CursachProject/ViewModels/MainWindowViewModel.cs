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
    public interface IAddable
    {
        void AddToCollection<T>(ObservableCollection<T> collection) where T : class;
    }

    public class Position
    {
        public string Title { get; set; }
    }

    public class Person : IAddable
    {
        public string FullName { get; set; }
        public string ContactInformation { get; set; }
        public Position Role { get; set; }
        public ObservableCollection<Membership> Memberships { get; } = new ObservableCollection<Membership>();
        public int Id { get; internal set; }

        public void AddToCollection<T>(ObservableCollection<T> collection) where T : class
        {
            if (this is T item)
            {
                collection.Add(item);
            }
        }
    }

    public class MainWindowViewModel : ReactiveObject
    {
        private ObservableCollection<Person> persons;
        private Person selectedPerson;
        private ObservableCollection<Person> employees;

        public ObservableCollection<Person> Persons
        {
            get => persons;
            set => this.RaiseAndSetIfChanged(ref persons, value);
        }

        public ObservableCollection<Person> Employees
        {
            get => employees;
            set => this.RaiseAndSetIfChanged(ref employees, value);
        }

        public Person SelectedPerson
        {
            get => selectedPerson;
            set => this.RaiseAndSetIfChanged(ref selectedPerson, value);
        }

        public ReactiveCommand<Unit, Unit> AddClientCommand { get; }
        public ReactiveCommand<Unit, Unit> AddMembershipCommand { get; }
        public ReactiveCommand<Unit, Unit> AddEmployeeCommand { get; }

        public MainWindowViewModel()
        {
            Persons = new ObservableCollection<Person>();
            Employees = new ObservableCollection<Person>();

            AddClientCommand = ReactiveCommand.Create(() => new Person { FullName = "Новый клиент", ContactInformation = "Новая контактная информация" }.AddToCollection(Persons));

            AddMembershipCommand = ReactiveCommand.Create(() =>
            {
                if (SelectedPerson != null)
                {
                    SelectedPerson.Memberships.Add(new Membership
                    {
                        Id = GenerateRandomId(),
                        PersonId = SelectedPerson.Id,
                        Person = SelectedPerson,
                        MemberName = "NewMember"
                    });
                }
            });

            AddEmployeeCommand = ReactiveCommand.Create(() => new Person { FullName = "Новый сотрудник", Role = new Position { Title = "Должность" } }.AddToCollection(Employees));
        }

        private int GenerateRandomId()
        {
            var random = new Random();
            return random.Next(1, 1000);
        }
    }
}