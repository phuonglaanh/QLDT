using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace Core
{
    public class CBO
    {
        public static List<PropertyInfo> GetPropertyInfo(Type objType)
        {
            List<PropertyInfo> objProperties = (List<PropertyInfo>)DataCache.GetCache(objType.FullName);
            if (objProperties == null)
            {
                objProperties = new List<PropertyInfo>();
                foreach (PropertyInfo tempLoopVar_objProperty in objType.GetProperties())
                {
                    objProperties.Add(tempLoopVar_objProperty);
                }
                objProperties.TrimExcess();
                DataCache.SetCache(objType.FullName, objProperties);
            }
            return objProperties;
        }
        private static int[] GetOrdinals(List<PropertyInfo> objProperties, IDataReader dr)
        {
            int[] arrOrdinals = new int[objProperties.Count];
            if (dr != null)
            {
                int count = objProperties.Count - 1;
                for (int i = 0; i <= count; i++)
                {
                    arrOrdinals[i] = -1;
                    try
                    {
                        arrOrdinals[i] = dr.GetOrdinal(objProperties[i].Name);
                    }
                    catch   // property does not exist in datareader
                    {

                    }
                }
            }
            return arrOrdinals;
        }
        private static object CreateObject(Type objType, IDataReader dr, List<PropertyInfo> objProperties, int[] arrOrdinals)
        {
            object objObject = Activator.CreateInstance(objType);
            int count = objProperties.Count - 1;
            for (int i = 0; i <= count; i++)
            {
                if (objProperties[i].CanWrite)
                {
                    if (arrOrdinals[i] != -1)
                    {
                        if (Convert.IsDBNull(dr.GetValue(arrOrdinals[i])))
                        {
                            objProperties[i].SetValue(objObject, Null.SetNull(objProperties[i]), null);
                        }
                        else
                        {
                            try
                            {
                                objProperties[i].SetValue(objObject, dr.GetValue(arrOrdinals[i]), null);
                            }
                            catch
                            {
                                try
                                {
                                    Type pType = objProperties[i].PropertyType;
                                    if (pType.BaseType.Equals(typeof(Enum)))
                                    {
                                        objProperties[i].SetValue(objObject, Enum.ToObject(pType, dr.GetValue(arrOrdinals[i])), null);
                                    }
                                    else
                                    {
                                        objProperties[i].SetValue(objObject, Convert.ChangeType(dr.GetValue(arrOrdinals[i]), pType), null);
                                    }
                                }
                                catch
                                {
                                    // property does not exist in datareader
                                    objProperties[i].SetValue(objObject, Null.SetNull(objProperties[i]), null);
                                }
                            }
                        }
                    }
                }
            }
            return objObject;
        }
        public static object FillObject(IDataReader dr, Type objType)
        {
            object objFillObject;
            List<PropertyInfo> objProperties = GetPropertyInfo(objType);
            int[] arrOrdinals = GetOrdinals(objProperties, dr);
            if (dr != null && dr.Read())
            {
                objFillObject = CreateObject(objType, dr, objProperties, arrOrdinals);
            }
            else
            {
                objFillObject = null;
            }
            if (dr != null)
            {
                dr.Close();
            }
            return objFillObject;
        }
        public static ArrayList FillCollection(IDataReader dr, Type objType)
        {
            ArrayList objFillCollection = new ArrayList();
            if (dr == null)
                return objFillCollection;
            object objFillObject;
            List<PropertyInfo> objProperties = GetPropertyInfo(objType);
            int[] arrOrdinals = GetOrdinals(objProperties, dr);
            while (dr.Read())
            {
                objFillObject = CreateObject(objType, dr, objProperties, arrOrdinals);
                objFillCollection.Add(objFillObject);
            }
            if (dr != null)
            {
                dr.Close();
            }
            return objFillCollection;
        }
        public static IList FillCollection(IDataReader dr, Type objType, IList objToFill)
        {
            if (dr == null)
                return objToFill;
            object objFillObject;
            List<PropertyInfo> objProperties = GetPropertyInfo(objType);
            int[] arrOrdinals = GetOrdinals(objProperties, dr);
            while (dr.Read())
            {
                objFillObject = CreateObject(objType, dr, objProperties, arrOrdinals);
                objToFill.Add(objFillObject);
            }
            if (dr != null)
            {
                dr.Close();
            }
            return objToFill;
        }

        private static T CreateObject<T>(IDataReader dr, List<PropertyInfo> objProperties, int[] arrOrdinals) where T : class, new()
        {
            T objObject = new T();
            int count = objProperties.Count - 1;
            for (int i = 0; i <= count; i++)
            {
                if (objProperties[i].CanWrite)
                {
                    if (arrOrdinals[i] != -1)
                    {
                        if (Convert.IsDBNull(dr.GetValue(arrOrdinals[i])))
                        {
                            objProperties[i].SetValue(objObject, Null.SetNull(objProperties[i]), null);
                        }
                        else
                        {
                            try
                            {
                                objProperties[i].SetValue(objObject, dr.GetValue(arrOrdinals[i]), null);
                            }
                            catch
                            {
                                try
                                {
                                    Type pType = objProperties[i].PropertyType;
                                    if (pType.BaseType.Equals(typeof(Enum)))
                                    {
                                        objProperties[i].SetValue(objObject, Enum.ToObject(pType, dr.GetValue(arrOrdinals[i])), null);
                                    }
                                    else
                                    {
                                        objProperties[i].SetValue(objObject, Convert.ChangeType(dr.GetValue(arrOrdinals[i]), pType), null);
                                    }
                                }
                                catch
                                {
                                    // property does not exist in datareader
                                    objProperties[i].SetValue(objObject, Null.SetNull(objProperties[i]), null);
                                }
                            }
                        }
                    }
                }
            }
            return objObject;
        }
        public static T FillObject<T>(IDataReader dr) where T : class, new()
        {
            T objFillObject = new T();
            List<PropertyInfo> objProperties = GetPropertyInfo(typeof(T));
            int[] arrOrdinals = GetOrdinals(objProperties, dr);
            if (dr != null && dr.Read())
            {
                objFillObject = CreateObject<T>(dr, objProperties, arrOrdinals);
            }
            else
            {
                objFillObject = null;
            }
            if (dr != null)
            {
                dr.Close();
            }
            return objFillObject;
        }
        public static C FillCollection<T, C>(IDataReader dr)
            where T : class, new()
            where C : ICollection<T>, new()
        {
            C objFillCollection = new C();
            if (dr == null)
                return objFillCollection;
            T objFillObject;
            List<PropertyInfo> objProperties = GetPropertyInfo(typeof(T));
            int[] arrOrdinals = GetOrdinals(objProperties, dr);
            while (dr.Read())
            {
                objFillObject = CreateObject<T>(dr, objProperties, arrOrdinals);
                objFillCollection.Add(objFillObject);
            }
            if (dr != null)
            {
                dr.Close();
            }
            return objFillCollection;
        }
        public static List<T> FillCollection<T>(IDataReader dr) where T : class, new()
        {
            return FillCollection<T, List<T>>(dr);
        }

        public static IList<T> FillCollection<T>(IDataReader dr, IList<T> objToFill) where T : class, new()
        {
            if (dr == null)
                return objToFill;
            T objFillObject;
            List<PropertyInfo> objProperties = GetPropertyInfo(typeof(T));
            int[] arrOrdinals = GetOrdinals(objProperties, dr);
            while (dr.Read())
            {
                objFillObject = CreateObject<T>(dr, objProperties, arrOrdinals);
                objToFill.Add(objFillObject);
            }
            if (dr != null)
            {
                dr.Close();
            }
            return objToFill;
        }

        public static object InitializeObject(object objObject, Type objType)
        {
            List<PropertyInfo> objProperties = GetPropertyInfo(objType);
            int count = objProperties.Count - 1;
            for (int i = 0; i <= count; i++)
            {
                if (objProperties[i].CanWrite)
                {
                    objProperties[i].SetValue(objObject, Null.SetNull((PropertyInfo)objProperties[i]), null);
                }
            }
            return objObject;
        }
    }
}
