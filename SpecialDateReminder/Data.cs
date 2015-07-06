using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Special_Date_Reminder
{
    public class Calendar
    {
        public List<Person> People { get; set; }
        public void Add_Person(Person person)
        {
            People.Add(person);
        }
        public void Remove_Person(Person person)
        {
            People.Remove(person);
        }
        public void Update_Existing_Person(Person person, string first_name, string last_name)
        {
            person.First_Name = first_name;
            person.Last_Name = last_name;
        }

        public List<Event> Events { get; set; }
        public void Add_Event(Event ev)
        {
            Events.Add(ev);
        }
        public void Remove_Event(Event ev)
        {
            Events.Remove(ev);
        }
        public void Update_Existing_Event(Event ev, Anniversary_Types anniversary_type, Person person, DateTime date)
        {
            ev.Anniversary_Type = anniversary_type;
            ev.Person = person;
            ev.Date = date;
        }

        public List<Wish_List> Wish_Lists { get; set; }
        public void Add_Wish_List(Wish_List wish_list)
        {
            Wish_Lists.Add(wish_list);
        }
        public void Remove_Wish_List(Wish_List wish_list)
        {
            Wish_Lists.Remove(wish_list);
        }
        public void Update_Existing_Wish_List(Wish_List wish_list, Person owner, List<Wish_List_Item> wish_list_items)
        {
            wish_list.Owner = owner;
            wish_list.Wish_List_Items = wish_list_items;
        }

        public void Alert(Event ev)
        {
            throw new NotImplementedException();
        }

        public List<Event> Get_Events_From_Database()
        {
            throw new NotImplementedException();
        }
        public void Save_Events_To_Database(List<Event> events)
        {
            throw new NotImplementedException();
        }

        public List<Wish_List> Get_Wish_Lists_From_Database()
        {
            throw new NotImplementedException();
        }
        public void Save_Wish_Lists_To_Database(List<Wish_List> wish_lists)
        {
            throw new NotImplementedException();
        }

        public List<Person> Get_People_From_Database()
        {
            throw new NotImplementedException();
        }
        public void Save_People_To_Database(List<Person> people)
        {
            throw new NotImplementedException();
        }

        public void Monitor_Events()
        {
            while (true)
            {
                //monitor events to see if anything is in the near future
                //if found, alert user
                //allow user to dismiss alert and record this state so it doesn't happen again while program is running
            }
        }
    }

    public class Wish_List
    {
        public Person Owner { get; set; }
        public List<Wish_List_Item> Wish_List_Items { get; set; }
        public void Add_Wish_List_Item(Wish_List_Item wish_list_item)
        {
            Wish_List_Items.Add(wish_list_item);
        }
        public void Remove_Wish_List_Item(Wish_List_Item wish_list_item)
        {
            Wish_List_Items.Remove(wish_list_item);
        }
        public void Update_Existing_Wish_List_Item(Wish_List_Item wish_list_item, string name, string description, decimal cost)
        {
            wish_list_item.Name = name;
            wish_list_item.Description = description;
            wish_list_item.Cost = cost;
        }
    }

    public class Event
    {
        public Anniversary_Types Anniversary_Type { get; set; }
        public Person Person { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }

    public class Person
    {
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
    }

    public class Wish_List_Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
    }

    public enum Anniversary_Types
    {
        Birthday,
        Fathers_Day,
        Mothers_Day,
        Wedding_Anniversary,
    }
}