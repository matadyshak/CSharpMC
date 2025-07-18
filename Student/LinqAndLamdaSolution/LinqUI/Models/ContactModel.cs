﻿namespace LinqUI.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<int> Addresses { get; set; } = new List<int>();
    }
}
