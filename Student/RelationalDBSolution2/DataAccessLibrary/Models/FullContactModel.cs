﻿namespace SQLServerUI.Models
{
    public class FullContactModel
    {
        public BasicContactModel? BasicInfo { get; set; }

        public List<EmailAddressModel> EmailAddresses { get; set; } = new List<EmailAddressModel>();

        public List<PhoneNumberModel> PhoneNumbers { get; set; } = new List<PhoneNumberModel>();
    }
}