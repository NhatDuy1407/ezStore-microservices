﻿using Ws4vn.Microservices.Infrastructure.MongoDB;
using Microservices.Setting.ApplicationCore.Entities;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microservices.Setting.Infrastructure.Migration
{
    public static class DatabaseInitialization
    {
        public static void InitializeDatabase(IServiceProvider services)
        {
            PerformMigrations(services);
        }

        private static void PerformMigrations(IServiceProvider services)
        {
            var mongoDbContext = services.GetRequiredService<MongoDbContext>();

            if (!mongoDbContext.Set<Country>().Find(i => true).Any())
            {
                var i = 0;
                foreach (Country item in GetCountries())
                {
                    i++;
                    item.AutoId = i;
                    item.DisplayOrder = i;
                    mongoDbContext.Set<Country>().InsertOne(item);
                }
            }

            var vietNam = mongoDbContext.Set<Country>().Find(i => i.IsoCode == "VN").FirstOrDefault();
            if (vietNam != null)
            {
                var i = 1;
                foreach (Province item in GetVNProvinces())
                {
                    i++;
                    item.AutoId = i;
                    item.DisplayOrder = i;
                    item.CountryId = vietNam.AutoId;
                    mongoDbContext.Set<Province>().InsertOne(item);
                }
            }
        }

        public static IEnumerable<Country> GetCountries()
        {
            return new List<Country>
            {
                new Country { Name =  "Afghanistan", IsoCode = "AF" },
                new Country { Name =  "Aland Islands", IsoCode = "AX" },
                new Country { Name =  "Albania", IsoCode = "AL" },
                new Country { Name =  "Algeria", IsoCode = "DZ" },
                new Country { Name =  "American Samoa", IsoCode = "AS" },
                new Country { Name =  "AndorrA", IsoCode = "AD" },
                new Country { Name =  "Angola", IsoCode = "AO" },
                new Country { Name =  "Anguilla", IsoCode = "AI" },
                new Country { Name =  "Antarctica", IsoCode = "AQ" },
                new Country { Name =  "Antigua and Barbuda", IsoCode = "AG" },
                new Country { Name =  "Argentina", IsoCode = "AR" },
                new Country { Name =  "Armenia", IsoCode = "AM" },
                new Country { Name =  "Aruba", IsoCode = "AW" },
                new Country { Name =  "Australia", IsoCode = "AU" },
                new Country { Name =  "Austria", IsoCode = "AT" },
                new Country { Name =  "Azerbaijan", IsoCode = "AZ" },
                new Country { Name =  "Bahamas", IsoCode = "BS" },
                new Country { Name =  "Bahrain", IsoCode = "BH" },
                new Country { Name =  "Bangladesh", IsoCode = "BD" },
                new Country { Name =  "Barbados", IsoCode = "BB" },
                new Country { Name =  "Belarus", IsoCode = "BY" },
                new Country { Name =  "Belgium", IsoCode = "BE" },
                new Country { Name =  "Belize", IsoCode = "BZ" },
                new Country { Name =  "Benin", IsoCode = "BJ" },
                new Country { Name =  "Bermuda", IsoCode = "BM" },
                new Country { Name =  "Bhutan", IsoCode = "BT" },
                new Country { Name =  "Bolivia", IsoCode = "BO" },
                new Country { Name =  "Bosnia and Herzegovina", IsoCode = "BA" },
                new Country { Name =  "Botswana", IsoCode = "BW" },
                new Country { Name =  "Bouvet Island", IsoCode = "BV" },
                new Country { Name =  "Brazil", IsoCode = "BR" },
                new Country { Name =  "British Indian Ocean Territory", IsoCode = "IO" },
                new Country { Name =  "Brunei Darussalam", IsoCode = "BN" },
                new Country { Name =  "Bulgaria", IsoCode = "BG" },
                new Country { Name =  "Burkina Faso", IsoCode = "BF" },
                new Country { Name =  "Burundi", IsoCode = "BI" },
                new Country { Name =  "Cambodia", IsoCode = "KH" },
                new Country { Name =  "Cameroon", IsoCode = "CM" },
                new Country { Name =  "Canada", IsoCode = "CA" },
                new Country { Name =  "Cape Verde", IsoCode = "CV" },
                new Country { Name =  "Cayman Islands", IsoCode = "KY" },
                new Country { Name =  "Central African Republic", IsoCode = "CF" },
                new Country { Name =  "Chad", IsoCode = "TD" },
                new Country { Name =  "Chile", IsoCode = "CL" },
                new Country { Name =  "China", IsoCode = "CN" },
                new Country { Name =  "Christmas Island", IsoCode = "CX" },
                new Country { Name =  "Cocos (Keeling) Islands", IsoCode = "CC" },
                new Country { Name =  "Colombia", IsoCode = "CO" },
                new Country { Name =  "Comoros", IsoCode = "KM" },
                new Country { Name =  "Congo", IsoCode = "CG" },
                new Country { Name =  "Congo, The Democratic Republic of the", IsoCode = "CD" },
                new Country { Name =  "Cook Islands", IsoCode = "CK" },
                new Country { Name =  "Costa Rica", IsoCode = "CR" },
                new Country { Name =  "Cote D\"Ivoire", IsoCode = "CI" },
                new Country { Name =  "Croatia", IsoCode = "HR" },
                new Country { Name =  "Cuba", IsoCode = "CU" },
                new Country { Name =  "Cyprus", IsoCode = "CY" },
                new Country { Name =  "Czech Republic", IsoCode = "CZ" },
                new Country { Name =  "Denmark", IsoCode = "DK" },
                new Country { Name =  "Djibouti", IsoCode = "DJ" },
                new Country { Name =  "Dominica", IsoCode = "DM" },
                new Country { Name =  "Dominican Republic", IsoCode = "DO" },
                new Country { Name =  "Ecuador", IsoCode = "EC" },
                new Country { Name =  "Egypt", IsoCode = "EG" },
                new Country { Name =  "El Salvador", IsoCode = "SV" },
                new Country { Name =  "Equatorial Guinea", IsoCode = "GQ" },
                new Country { Name =  "Eritrea", IsoCode = "ER" },
                new Country { Name =  "Estonia", IsoCode = "EE" },
                new Country { Name =  "Ethiopia", IsoCode = "ET" },
                new Country { Name =  "Falkland Islands (Malvinas)", IsoCode = "FK" },
                new Country { Name =  "Faroe Islands", IsoCode = "FO" },
                new Country { Name =  "Fiji", IsoCode = "FJ" },
                new Country { Name =  "Finland", IsoCode = "FI" },
                new Country { Name =  "France", IsoCode = "FR" },
                new Country { Name =  "French Guiana", IsoCode = "GF" },
                new Country { Name =  "French Polynesia", IsoCode = "PF" },
                new Country { Name =  "French Southern Territories", IsoCode = "TF" },
                new Country { Name =  "Gabon", IsoCode = "GA" },
                new Country { Name =  "Gambia", IsoCode = "GM" },
                new Country { Name =  "Georgia", IsoCode = "GE" },
                new Country { Name =  "Germany", IsoCode = "DE" },
                new Country { Name =  "Ghana", IsoCode = "GH" },
                new Country { Name =  "Gibraltar", IsoCode = "GI" },
                new Country { Name =  "Greece", IsoCode = "GR" },
                new Country { Name =  "Greenland", IsoCode = "GL" },
                new Country { Name =  "Grenada", IsoCode = "GD" },
                new Country { Name =  "Guadeloupe", IsoCode = "GP" },
                new Country { Name =  "Guam", IsoCode = "GU" },
                new Country { Name =  "Guatemala", IsoCode = "GT" },
                new Country { Name =  "Guernsey", IsoCode = "GG" },
                new Country { Name =  "Guinea", IsoCode = "GN" },
                new Country { Name =  "Guinea-Bissau", IsoCode = "GW" },
                new Country { Name =  "Guyana", IsoCode = "GY" },
                new Country { Name =  "Haiti", IsoCode = "HT" },
                new Country { Name =  "Heard Island and Mcdonald Islands", IsoCode = "HM" },
                new Country { Name =  "Holy See (Vatican City State)", IsoCode = "VA" },
                new Country { Name =  "Honduras", IsoCode = "HN" },
                new Country { Name =  "Hong Kong", IsoCode = "HK" },
                new Country { Name =  "Hungary", IsoCode = "HU" },
                new Country { Name =  "Iceland", IsoCode = "IS" },
                new Country { Name =  "India", IsoCode = "IN" },
                new Country { Name =  "Indonesia", IsoCode = "ID" },
                new Country { Name =  "Iran, Islamic Republic Of", IsoCode = "IR" },
                new Country { Name =  "Iraq", IsoCode = "IQ" },
                new Country { Name =  "Ireland", IsoCode = "IE" },
                new Country { Name =  "Isle of Man", IsoCode = "IM" },
                new Country { Name =  "Israel", IsoCode = "IL" },
                new Country { Name =  "Italy", IsoCode = "IT" },
                new Country { Name =  "Jamaica", IsoCode = "JM" },
                new Country { Name =  "Japan", IsoCode = "JP" },
                new Country { Name =  "Jersey", IsoCode = "JE" },
                new Country { Name =  "Jordan", IsoCode = "JO" },
                new Country { Name =  "Kazakhstan", IsoCode = "KZ" },
                new Country { Name =  "Kenya", IsoCode = "KE" },
                new Country { Name =  "Kiribati", IsoCode = "KI" },
                new Country { Name =  "Korea, Democratic People\"S Republic of", IsoCode = "KP" },
                new Country { Name =  "Korea, Republic of", IsoCode = "KR" },
                new Country { Name =  "Kuwait", IsoCode = "KW" },
                new Country { Name =  "Kyrgyzstan", IsoCode = "KG" },
                new Country { Name =  "Lao People\"S Democratic Republic", IsoCode = "LA" },
                new Country { Name =  "Latvia", IsoCode = "LV" },
                new Country { Name =  "Lebanon", IsoCode = "LB" },
                new Country { Name =  "Lesotho", IsoCode = "LS" },
                new Country { Name =  "Liberia", IsoCode = "LR" },
                new Country { Name =  "Libyan Arab Jamahiriya", IsoCode = "LY" },
                new Country { Name =  "Liechtenstein", IsoCode = "LI" },
                new Country { Name =  "Lithuania", IsoCode = "LT" },
                new Country { Name =  "Luxembourg", IsoCode = "LU" },
                new Country { Name =  "Macao", IsoCode = "MO" },
                new Country { Name =  "Macedonia, The Former Yugoslav Republic of", IsoCode = "MK" },
                new Country { Name =  "Madagascar", IsoCode = "MG" },
                new Country { Name =  "Malawi", IsoCode = "MW" },
                new Country { Name =  "Malaysia", IsoCode = "MY" },
                new Country { Name =  "Maldives", IsoCode = "MV" },
                new Country { Name =  "Mali", IsoCode = "ML" },
                new Country { Name =  "Malta", IsoCode = "MT" },
                new Country { Name =  "Marshall Islands", IsoCode = "MH" },
                new Country { Name =  "Martinique", IsoCode = "MQ" },
                new Country { Name =  "Mauritania", IsoCode = "MR" },
                new Country { Name =  "Mauritius", IsoCode = "MU" },
                new Country { Name =  "Mayotte", IsoCode = "YT" },
                new Country { Name =  "Mexico", IsoCode = "MX" },
                new Country { Name =  "Micronesia, Federated States of", IsoCode = "FM" },
                new Country { Name =  "Moldova, Republic of", IsoCode = "MD" },
                new Country { Name =  "Monaco", IsoCode = "MC" },
                new Country { Name =  "Mongolia", IsoCode = "MN" },
                new Country { Name =  "Montserrat", IsoCode = "MS" },
                new Country { Name =  "Morocco", IsoCode = "MA" },
                new Country { Name =  "Mozambique", IsoCode = "MZ" },
                new Country { Name =  "Myanmar", IsoCode = "MM" },
                new Country { Name =  "Namibia", IsoCode = "NA" },
                new Country { Name =  "Nauru", IsoCode = "NR" },
                new Country { Name =  "Nepal", IsoCode = "NP" },
                new Country { Name =  "Netherlands", IsoCode = "NL" },
                new Country { Name =  "Netherlands Antilles", IsoCode = "AN" },
                new Country { Name =  "New Caledonia", IsoCode = "NC" },
                new Country { Name =  "New Zealand", IsoCode = "NZ" },
                new Country { Name =  "Nicaragua", IsoCode = "NI" },
                new Country { Name =  "Niger", IsoCode = "NE" },
                new Country { Name =  "Nigeria", IsoCode = "NG" },
                new Country { Name =  "Niue", IsoCode = "NU" },
                new Country { Name =  "Norfolk Island", IsoCode = "NF" },
                new Country { Name =  "Northern Mariana Islands", IsoCode = "MP" },
                new Country { Name =  "Norway", IsoCode = "NO" },
                new Country { Name =  "Oman", IsoCode = "OM" },
                new Country { Name =  "Pakistan", IsoCode = "PK" },
                new Country { Name =  "Palau", IsoCode = "PW" },
                new Country { Name =  "Palestinian Territory, Occupied", IsoCode = "PS" },
                new Country { Name =  "Panama", IsoCode = "PA" },
                new Country { Name =  "Papua New Guinea", IsoCode = "PG" },
                new Country { Name =  "Paraguay", IsoCode = "PY" },
                new Country { Name =  "Peru", IsoCode = "PE" },
                new Country { Name =  "Philippines", IsoCode = "PH" },
                new Country { Name =  "Pitcairn", IsoCode = "PN" },
                new Country { Name =  "Poland", IsoCode = "PL" },
                new Country { Name =  "Portugal", IsoCode = "PT" },
                new Country { Name =  "Puerto Rico", IsoCode = "PR" },
                new Country { Name =  "Qatar", IsoCode = "QA" },
                new Country { Name =  "Reunion", IsoCode = "RE" },
                new Country { Name =  "Romania", IsoCode = "RO" },
                new Country { Name =  "Russian Federation", IsoCode = "RU" },
                new Country { Name =  "RWANDA", IsoCode = "RW" },
                new Country { Name =  "Saint Helena", IsoCode = "SH" },
                new Country { Name =  "Saint Kitts and Nevis", IsoCode = "KN" },
                new Country { Name =  "Saint Lucia", IsoCode = "LC" },
                new Country { Name =  "Saint Pierre and Miquelon", IsoCode = "PM" },
                new Country { Name =  "Saint Vincent and the Grenadines", IsoCode = "VC" },
                new Country { Name =  "Samoa", IsoCode = "WS" },
                new Country { Name =  "San Marino", IsoCode = "SM" },
                new Country { Name =  "Sao Tome and Principe", IsoCode = "ST" },
                new Country { Name =  "Saudi Arabia", IsoCode = "SA" },
                new Country { Name =  "Senegal", IsoCode = "SN" },
                new Country { Name =  "Serbia and Montenegro", IsoCode = "CS" },
                new Country { Name =  "Seychelles", IsoCode = "SC" },
                new Country { Name =  "Sierra Leone", IsoCode = "SL" },
                new Country { Name =  "Singapore", IsoCode = "SG" },
                new Country { Name =  "Slovakia", IsoCode = "SK" },
                new Country { Name =  "Slovenia", IsoCode = "SI" },
                new Country { Name =  "Solomon Islands", IsoCode = "SB" },
                new Country { Name =  "Somalia", IsoCode = "SO" },
                new Country { Name =  "South Africa", IsoCode = "ZA" },
                new Country { Name =  "South Georgia and the South Sandwich Islands", IsoCode = "GS" },
                new Country { Name =  "Spain", IsoCode = "ES" },
                new Country { Name =  "Sri Lanka", IsoCode = "LK" },
                new Country { Name =  "Sudan", IsoCode = "SD" },
                new Country { Name =  "Suriname", IsoCode = "SR" },
                new Country { Name =  "Svalbard and Jan Mayen", IsoCode = "SJ" },
                new Country { Name =  "Swaziland", IsoCode = "SZ" },
                new Country { Name =  "Sweden", IsoCode = "SE" },
                new Country { Name =  "Switzerland", IsoCode = "CH" },
                new Country { Name =  "Syrian Arab Republic", IsoCode = "SY" },
                new Country { Name =  "Taiwan, Province of China", IsoCode = "TW" },
                new Country { Name =  "Tajikistan", IsoCode = "TJ" },
                new Country { Name =  "Tanzania, United Republic of", IsoCode = "TZ" },
                new Country { Name =  "Thailand", IsoCode = "TH" },
                new Country { Name =  "Timor-Leste", IsoCode = "TL" },
                new Country { Name =  "Togo", IsoCode = "TG" },
                new Country { Name =  "Tokelau", IsoCode = "TK" },
                new Country { Name =  "Tonga", IsoCode = "TO" },
                new Country { Name =  "Trinidad and Tobago", IsoCode = "TT" },
                new Country { Name =  "Tunisia", IsoCode = "TN" },
                new Country { Name =  "Turkey", IsoCode = "TR" },
                new Country { Name =  "Turkmenistan", IsoCode = "TM" },
                new Country { Name =  "Turks and Caicos Islands", IsoCode = "TC" },
                new Country { Name =  "Tuvalu", IsoCode = "TV" },
                new Country { Name =  "Uganda", IsoCode = "UG" },
                new Country { Name =  "Ukraine", IsoCode = "UA" },
                new Country { Name =  "United Arab Emirates", IsoCode = "AE" },
                new Country { Name =  "United Kingdom", IsoCode = "GB" },
                new Country { Name =  "United States", IsoCode = "US" },
                new Country { Name =  "United States Minor Outlying Islands", IsoCode = "UM" },
                new Country { Name =  "Uruguay", IsoCode = "UY" },
                new Country { Name =  "Uzbekistan", IsoCode = "UZ" },
                new Country { Name =  "Vanuatu", IsoCode = "VU" },
                new Country { Name =  "Venezuela", IsoCode = "VE" },
                new Country { Name =  "Viet Nam", IsoCode = "VN" },
                new Country { Name =  "Virgin Islands, British", IsoCode = "VG" },
                new Country { Name =  "Virgin Islands, U.S.", IsoCode = "VI" },
                new Country { Name =  "Wallis and Futuna", IsoCode = "WF" },
                new Country { Name =  "Western Sahara", IsoCode = "EH" },
                new Country { Name =  "Yemen", IsoCode = "YE" },
                new Country { Name =  "Zambia", IsoCode = "ZM" },
                new Country { Name =  "Zimbabwe", IsoCode = "ZW"}
            };
        }

        public static IEnumerable<Province> GetVNProvinces()
        {
            return new List<Province> {
                new Province { Name = "Thành phố Hà Nội" },
                new Province { Name = "Tỉnh Hà Giang" },
                new Province { Name = "Tỉnh Cao Bằng" },
                new Province { Name = "Tỉnh Bắc Kạn" },
                new Province { Name = "Tỉnh Tuyên Quang" },
                new Province { Name = "Tỉnh Lào Cai" },
                new Province { Name = "Tỉnh Điện Biên" },
                new Province { Name = "Tỉnh Lai Châu" },
                new Province { Name = "Tỉnh Sơn La" },
                new Province { Name = "Tỉnh Yên Bái" },
                new Province { Name = "Tỉnh Hoà Bình" },
                new Province { Name = "Tỉnh Thái Nguyên" },
                new Province { Name = "Tỉnh Lạng Sơn" },
                new Province { Name = "Tỉnh Quảng Ninh" },
                new Province { Name = "Tỉnh Bắc Giang" },
                new Province { Name = "Tỉnh Phú Thọ" },
                new Province { Name = "Tỉnh Vĩnh Phúc" },
                new Province { Name = "Tỉnh Bắc Ninh" },
                new Province { Name = "Tỉnh Hải Dương" },
                new Province { Name = "Thành phố Hải Phòng" },
                new Province { Name = "Tỉnh Hưng Yên" },
                new Province { Name = "Tỉnh Thái Bình" },
                new Province { Name = "Tỉnh Hà Nam" },
                new Province { Name = "Tỉnh Nam Định" },
                new Province { Name = "Tỉnh Ninh Bình" },
                new Province { Name = "Tỉnh Thanh Hóa" },
                new Province { Name = "Tỉnh Nghệ An" },
                new Province { Name = "Tỉnh Hà Tĩnh" },
                new Province { Name = "Tỉnh Quảng Bình" },
                new Province { Name = "Tỉnh Quảng Trị" },
                new Province { Name = "Tỉnh Thừa Thiên Huế" },
                new Province { Name = "Thành phố Đà Nẵng" },
                new Province { Name = "Tỉnh Quảng Nam" },
                new Province { Name = "Tỉnh Quảng Ngãi" },
                new Province { Name = "Tỉnh Bình Định" },
                new Province { Name = "Tỉnh Phú Yên" },
                new Province { Name = "Tỉnh Khánh Hòa" },
                new Province { Name = "Tỉnh Ninh Thuận" },
                new Province { Name = "Tỉnh Bình Thuận" },
                new Province { Name = "Tỉnh Kon Tum" },
                new Province { Name = "Tỉnh Gia Lai" },
                new Province { Name = "Tỉnh Đắk Lắk" },
                new Province { Name = "Tỉnh Đắk Nông" },
                new Province { Name = "Tỉnh Lâm Đồng" },
                new Province { Name = "Tỉnh Bình Phước" },
                new Province { Name = "Tỉnh Tây Ninh" },
                new Province { Name = "Tỉnh Bình Dương" },
                new Province { Name = "Tỉnh Đồng Nai" },
                new Province { Name = "Tỉnh Bà Rịa - Vũng Tàu" },
                new Province { Name = "Thành phố Hồ Chí Minh" },
                new Province { Name = "Tỉnh Long An" },
                new Province { Name = "Tỉnh Tiền Giang" },
                new Province { Name = "Tỉnh Bến Tre" },
                new Province { Name = "Tỉnh Trà Vinh" },
                new Province { Name = "Tỉnh Vĩnh Long" },
                new Province { Name = "Tỉnh Đồng Tháp" },
                new Province { Name = "Tỉnh An Giang" },
                new Province { Name = "Tỉnh Kiên Giang" },
                new Province { Name = "Thành phố Cần Thơ" },
                new Province { Name = "Tỉnh Hậu Giang" },
                new Province { Name = "Tỉnh Sóc Trăng" },
                new Province { Name = "Tỉnh Bạc Liêu" },
                new Province { Name = "Tỉnh Cà Mau" },
            };
        }
    }
}
