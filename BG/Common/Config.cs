using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;

namespace BG.Common
{
    public static class Config
    {
        public static readonly string API = "http://localhost:56718/";
        public static readonly string TokenURL = "Token";
        public static readonly string TokenType = "bearer";
        public static readonly string Register = "api/Account/Register";
        public static readonly string Counter = "api/Account/Counter";


        // API URL
        public static readonly string logout = "api/Account/Logout";


        public static readonly string color_master = "api/master/color-master";
        public static readonly string certificate_master = "api/master/certificate-master";
        public static readonly string cut_master = "api/master/cut-master";
        public static readonly string purity_master = "api/master/purity-master";
        public static readonly string flou_master = "api/master/flou-master";
        public static readonly string size_master = "api/master/size-master";
        public static readonly string party_master = "api/master/party-master";
        public static readonly string fancy_color_master = "api/master/fancy-color-master";
        public static readonly string fancy_ot_master = "api/master/fancy-ot-master";
        public static readonly string shape_master = "api/master/shap-master";

        // Customer API
        public static readonly string new_customers = "api/customer/new";
        public static readonly string Register_customers = "api/customer/register";
        public static readonly string get_customer_detail = "api/customer/details";
        public static readonly string customer_deactivate = "api/customer/deactivate";
        public static readonly string customer_activate = "api/customer/activate";
        public static readonly string new_customer_activate = "api/customer/new-customer-activate";

        // Dashboard API
        public static readonly string dashboard = "api/dashboard";

        // Stock API
        public static readonly string get_stock = "api/stock";

        // Broker API
        public static readonly string get_broker = "api/broker";
        public static readonly string get_broker_Columns = "api/broker/get-stock";
        public static readonly string get_broker_stocks = "api/broker/get-broker-stock";

        //Sales person API
        public static readonly string get_sales_persons = "api/sales-person";




        // Get Enum description value
        // @(Utility.GetEnumDescription((EnumType.VMProjectType)(int)Enum.Parse(typeof(EnumType.VMProjectType), item.ProjectType)))
        public static string GetEnumDescription(Enum value)
        {
            try
            {
                FieldInfo fi = value.GetType().GetField(value.ToString());
                DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];
                if (attributes != null && attributes.Any())
                {
                    return attributes.First().Description;
                }
                return value.ToString();
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
    } 
}