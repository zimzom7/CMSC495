/********************************************REVISION HISTORY********************************************
2015-07-11  Jana    Created functions to interact with dataset that is correlated with database




********************************************************************************************************/

using SpecialDateReminder;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SpecialDateReminder
{
    public class Calendar
    {
        SDRDataSet SDRDataSet { get; set; }
        public Calendar(SDRDataSet sdrDataSet)
        {
            // Create dataset and populate from database and set up so updates can be done.
            SDRDataSet = sdrDataSet;
        }
        public void Add_Person(string person_name)
        {
            SDRDataSet.Person.AddPersonRow(person_name);
        }
        public void Remove_Person(string person_name)
        {
            SDRDataSet.PersonRow person = SDRDataSet.Person.FindByPerson_Name(person_name);
            SDRDataSet.Person.RemovePersonRow(person);
        }

        public void Add_Event(DateTime date, string event_name, string event_description, string person_name)
        {
            SDRDataSet.PersonRow person = SDRDataSet.Person.FindByPerson_Name(person_name);
            SDRDataSet.Event.AddEventRow(date, event_name, event_description, person);
        }
        public void Remove_Event(DateTime date, string event_name)
        {
            SDRDataSet.EventRow evnt = SDRDataSet.Event.FindByDateEvent_Name(date, event_name);
            SDRDataSet.Event.RemoveEventRow(evnt);
        }

        public void Add_Wish_List(string person_name, string wish_list_name, string wish_list_description)
        {
            SDRDataSet.PersonRow person = SDRDataSet.Person.FindByPerson_Name(person_name);
            SDRDataSet.Wish_List.AddWish_ListRow(person, wish_list_name, wish_list_description);
        }
        public void Remove_Wish_List(string person_name, string wish_list_name)
        {
            SDRDataSet.Wish_ListRow wish_list = SDRDataSet.Wish_List.FindByPerson_NameList_Name(person_name, wish_list_name);
            SDRDataSet.Wish_List.RemoveWish_ListRow(wish_list);
        }

        public void Add_Wish_List_Item(string person_name, string wish_list_name, string wish_list_item_name, string wish_list_item_description)
        {
            SDRDataSet.Wish_List_Item.AddWish_List_ItemRow(person_name, wish_list_name, wish_list_item_name, wish_list_item_description);
        }
        public void Remove_Wish_List_Item(string person_name, string wish_list_name, string wish_list_item_name)
        {

            SDRDataSet.Wish_List_ItemRow wish_list_item = SDRDataSet.Wish_List_Item.FindByPerson_NameList_NameItem_Name(person_name, wish_list_name, wish_list_item_name);
            SDRDataSet.Wish_List_Item.RemoveWish_List_ItemRow(wish_list_item);
        }

        public void Alert()
        {
            throw new NotImplementedException();
        }
    }
}