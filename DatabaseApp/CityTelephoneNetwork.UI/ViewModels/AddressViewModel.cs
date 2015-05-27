using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using Caliburn.Micro;
using CityTelephoneNetwork.Data;

namespace CityTelephoneNetwork.UI.ViewModels
{
    public class AddressViewModel : PropertyChangedBase, IDataErrorInfo
    {
        public Address AddressEntity { get; private set; }

        public void SetAddress(Address address)
        {
            AddressEntity = address;
        }

        public string Index
        {
            get { return AddressEntity.Index; }
            set
            {
                if (AddressEntity.Index == value)
                    return;

                AddressEntity.Index = value;
                NotifyOfPropertyChange(() => Index);
            }
        }

        public string District
        {
            get { return AddressEntity.District; }
            set
            {
                if (AddressEntity.District == value)
                    return;

                AddressEntity.District = value;
                NotifyOfPropertyChange(() => District);
            }
        }

        public string Street
        {
            get { return AddressEntity.Street; }
            set
            {
                if (AddressEntity.Street == value)
                    return;

                AddressEntity.Street = value;
                NotifyOfPropertyChange(() => Street);
            }
        }

        public string House
        {
            get { return AddressEntity.House; }
            set
            {
                if (AddressEntity.House == value)
                    return;

                AddressEntity.House = value;
                NotifyOfPropertyChange(() => House);
            }
        }

        public string Flat
        {
            get { return AddressEntity.Flat; }
            set
            {
                if (AddressEntity.Flat == value)
                    return;

                AddressEntity.Flat = value;
                NotifyOfPropertyChange(() => Flat);
            }
        }



        //Мы понимаем, что строки хардкодить плохо, но у нас осталось мало времени на то, чтобы заниматься красотой =)
        public string this[string columnName]
        {
            get
            {
                Error = null;
                string msg = null;
                switch (columnName)
                {
                    case "Index":
                        if (string.IsNullOrEmpty(Index))
                        {
                            msg = "Index is required, please, fill this field";
                            break;
                        }
                        if (!Regex.IsMatch(Index, @"^[0-9A-Z]{1,6}$"))
                            msg = "Index must contain maximum 6 symbols(numbers and upper letters)";
                        break;
                    case "District":
                        if (string.IsNullOrEmpty(District))
                        {
                            msg = "District is required, please, fill this field";
                            break;
                        }
                        if (!Regex.IsMatch(District, @"^[a-zа-яА-ЯA-Z0-9\s]+$"))
                            msg = "District can't contain special symbols";
                        break;
                    case "Street":
                        if (string.IsNullOrEmpty(Street))
                        {
                            msg = "Street is required, please, fill this field";
                            break;
                        }
                        if (!Regex.IsMatch(Street, @"^[a-zA-Zа-яА-Я0-9\s]+$"))
                            msg = "Street can't contain special symbols";
                        break;
                    case "House":
                        if (string.IsNullOrEmpty(House))
                        {
                            msg = "House is required, please, fill this field";
                            break;
                        }
                        if (!Regex.IsMatch(House, @"^[0-9]+((\/[0-9])|[a-zа-я]){0,1}$"))
                            msg = "Incorrect house field format";
                        break;
                    case "Flat":
                        if (string.IsNullOrEmpty(Flat))
                        {
                            msg = "Flat is required, please, fill this field";
                            break;
                        }
                        if (!Regex.IsMatch(Flat, @"^[0-9]+[a-zа-я]{0,1}$"))
                            msg = "Flat can't contain special symbols";
                        break;
                }
                Error = msg;
                return msg;
            }
        }

        public string Error { get; private set; }
    }
}
