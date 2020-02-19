using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BG.Common
{
    public static class Config
    {
        public static readonly string API = "http://localhost:56718/";
        public static readonly string TokenURL = "Token";
        public static readonly string TokenType = "bearer";


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

        public static readonly string new_customers = "api/customer/customers";
        public static readonly string get_customer_detail = "api/customer/details";
        public static readonly string dashboard = "api/dashboard";
    }  
}