using Store.Common;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.StaticFiles;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Store
{
    /// <summary>
    /// This Class Is Resposible for all extention method in the app
    /// we removed Common from Electricity.Common namespace to make this class public 
    /// for the all application
    /// </summary>
    public static class ExtentionMethods
    {


        public static string IsValid(this object mdl)
        {
            var d = (mdl.GetType().GetProperties().Where(x => string.IsNullOrEmpty(x.GetValue(mdl)?.ToString() ?? "")))?.FirstOrDefault();
            if (d != null)
            {
                return d.Name;
            }
            return "";

        }
        public static string GetMessage(this object mdl)
        {
            var PropertyName = mdl.IsValid();
            if (!string.IsNullOrWhiteSpace(PropertyName))
            {
                return string.Format(AppConstants.Messages.ThisFieldRequierd, PropertyName);
            }
            return "";

        }
        #region Get Url , Action ,etc

        /// <summary>
        /// Get The Specified Action Followed By its Controller and Area if exists
        /// </summary>
        /// <param name="html">The Current Html Helper</param>
        /// <param name="action">The Required Action At Same Area</param>
        /// <returns></returns>
        public static string GetAction(this IUrlHelper html, string action)
        {
            string _url = "/";
            if (html.ActionContext.HttpContext.GetRouteValue("area") != null)
                _url += html.ActionContext.HttpContext.GetRouteValue("area").ToString() + "/";
            _url += html.ActionContext.HttpContext.GetRouteValue("controller").ToString() + "/";
            _url += action;
            return _url;
        }


        #endregion
    }

}
