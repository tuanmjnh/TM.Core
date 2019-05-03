﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace TM.Core.Helpers
{
    public static class TMClass
    {
        //var dfdf = new Models.MYTV();
        //var name = dfdf.GetType().Name;
        //var proper = dfdf.GetType().GetProperties()[2].PropertyType;
        //        foreach (var p in dfdf.GetType().GetProperties())
        //        {
        //            var names = p.Name;
        //var value = p.GetValue(dfdf, null);
        public static string GetClassName<T>(this T obj)
        {
            return obj.GetType().Name;
        }
        public static List<string> GetProperties<T>(this T obj)
        {
            var rs = new List<string>();
            foreach (var p in obj.GetType().GetProperties())
                rs.Add(p.Name);
            return rs;
        }
        public static Dictionary<string, dynamic> GetPropertiesValues<T>(this T obj)
        {
            var rs = new Dictionary<string, dynamic>();
            foreach (var p in obj.GetType().GetProperties())
                rs.Add(p.Name, p.GetValue(obj, null));
            return rs;
        }
        public static bool isList<T>(this T obj)
        {
            if (obj is IList && obj.GetType().IsGenericType)
                return true;
            return false;
        }
    }
}
