using System;
using System.Reflection;

namespace Core
{
    // Null Class
    // Class for dealing with the translation of database null values. 

    public class Null
    {
        public static string NullString
        {
            get
            {
                return "";
            }
        }
        public static bool NullBoolean
        {
            get
            {
                return false;
            }
        }
       
        public static DateTime NullDate
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public static decimal NullDecimal
        {
            get
            {
                return decimal.MinValue;
            }
        }
        public static double NullDouble
        {
            get
            {
                return double.MinValue;
            }
        }
        public static Guid NullGuid
        {
            get
            {
                return Guid.Empty;
            }
        }
        public static int NullInteger
        {
            get
            {
                return -1;
            }
        }
        public static short NullShort
        {
            get
            {
                return -1;
            }
        }
        public static float NullSingle
        {
            get
            {
                return float.MinValue;
            }
        }

        // convert an application encoded null value to a database null value ( used in DAL )
        public static object GetNull(object objField, object objDBNull)
        {
            if (objField == null)
                return objDBNull;
            if (objField is short && Convert.ToInt16(objField) == NullShort)
                return objDBNull;
            if (objField is int && Convert.ToInt32(objField) == NullInteger)
                return objDBNull;
            if (objField is float && Convert.ToSingle(objField) == NullSingle)
                return objDBNull;
            if (objField is double && Convert.ToDouble(objField) == NullDouble)
                return objDBNull;
            if (objField is decimal && Convert.ToDecimal(objField) == NullDecimal)
                return objDBNull;
            if (objField is DateTime && Convert.ToDateTime(objField).Date == NullDate)
                return objDBNull;
            if (objField is bool && Convert.ToBoolean(objField) == NullBoolean)
                return objDBNull;
            if (objField is string)
            {
                if (objField == null)
                    return objDBNull;
                if (objField.ToString() == NullString)
                    return objDBNull;
            }
            if (objField is Guid)
            {
                Guid guild = (Guid)objField;
                if (guild.Equals(NullGuid))
                    return objDBNull;
            }
            return objField;
        }

        // checks if a field contains an application encoded null value
        public static bool IsNull(object objField)
        {
            if (objField != null)
            {
                if (objField is int)
                {
                    return objField.Equals(NullInteger);
                }
                if (objField is float)
                {
                    return objField.Equals(NullSingle);
                }
                if (objField is double)
                {
                    return objField.Equals(NullDouble);
                }
                if (objField is decimal)
                {
                    return objField.Equals(NullDecimal);
                }
                if (objField is DateTime)
                {
                    DateTime objDateTime = Convert.ToDateTime(objField);
                    return objDateTime.Date.Equals(NullDate);
                }
                if (objField is string)
                {
                    return objField.Equals(NullString);
                }
                if (objField is bool)
                {
                    return objField.Equals(NullBoolean);
                }
                if (objField is Guid)
                {
                    return objField.Equals(NullGuid);
                }
                return false;
            }
            return true;
        }

        // sets a field to an application encoded null value ( used in BLL layer )
        public static object SetNull(object objValue, object objField)
        {
            if (Convert.IsDBNull(objValue))
            {
                if (objField is short)
                {
                    return NullShort;
                }
                if (objField is int)
                {
                    return NullInteger;
                }
                if (objField is float)
                {
                    return NullSingle;
                }
                if (objField is double)
                {
                    return NullDouble;
                }
                if (objField is decimal)
                {
                    return NullDecimal;
                }
                if (objField is DateTime)
                {
                    return NullDate;
                }
                if (objField is string)
                {
                    return NullString;
                }
                if (objField is bool)
                {
                    return NullBoolean;
                }
                if (objField is Guid)
                {
                    return NullGuid;
                }
                return null;
            }
            return objValue;
        }
        public static object SetNull(PropertyInfo objPropertyInfo)
        {
            switch (objPropertyInfo.PropertyType.ToString())
            {
                case "System.Int16":
                    return NullShort;
                case "System.Int32":
                    return NullInteger;
                case "System.Single":
                    return NullSingle;
                case "System.Double":
                    return NullDouble;
                case "System.Decimal":
                    return NullDecimal;
                case "System.DateTime":
                    return NullDate;
                case "System.String":
                    return NullString;
                case "System.Boolean":
                    return NullBoolean;
                case "System.Guid":
                    return NullGuid;
                default:
                    Type pType = objPropertyInfo.PropertyType;
                    if (pType.BaseType.Equals(typeof(Enum)))
                    {
                        Array objEnumValues = Enum.GetValues(pType);
                        Array.Sort(objEnumValues);
                        return Enum.ToObject(pType, objEnumValues.GetValue(0));
                    }
                    return null;
            }
        }
    }
}
