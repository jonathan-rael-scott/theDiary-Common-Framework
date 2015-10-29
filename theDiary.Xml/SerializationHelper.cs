﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

namespace theDiary.Xml
{
    public static class SerializationHelper
    {
        private static readonly Lazy<IEnumerable<Type>> primitiveTypes = new Lazy<IEnumerable<Type>>(SerializationHelper.GetPrimitiveTypes, true);
        private const string SerializerTypeFormat = "{0}.{1}";
        private static readonly Func<IEnumerable<Type>> GetPrimitiveTypes = new Func<IEnumerable<Type>>(()=>typeof(int).Assembly.GetTypes().Where(a=>a.IsPrimitive || a.Equals(typeof(string))));
        
        

        

        public static void Serialize(object instance, out string xmlContent, out string serializerType)
        {
            SerializerTypes serializerTypeValue = SerializerTypes.Primitive;
            xmlContent = string.Empty;
            Type instanceType = typeof(object);
            if (instance != null)
            {                
                if (instanceType.IsPrimitive || instanceType == typeof(string))
                {
                    xmlContent = string.Format("<{0}>{1}</{0}>", instanceType.Name, instance);
                }
                else if (instanceType.GetCustomAttributes(typeof(SerializableAttribute), true).FirstOrDefault() != null)
                {
                    serializerTypeValue = SerializerTypes.XmlSerializer;
                    StringWriter sww = new StringWriter();
                    XmlWriter writer = XmlWriter.Create(sww);
                    System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(instanceType);
                    serializer.Serialize(sww, instanceType);
                    xmlContent = sww.ToString();
                }
                else
                {
                    serializerTypeValue = SerializerTypes.XmlObjectSerializer;
                    XmlObjectSerializer serializer = new XmlObjectSerializer();
                    xmlContent = serializer.Serialize(instance, instanceType).OuterXml;
                }
            }

            serializerType = string.Format(SerializerTypeFormat, serializerTypeValue, instanceType.AssemblyQualifiedName);
        }

        public static object Deserialize(string xmlContent, string serializerType)
        {
            object returnValue = null;
            SerializerTypes serializerTypeValue;
            Type instanceType;
            GetSerializerDetails(serializerType, out serializerTypeValue, out instanceType);
            
            if (serializerTypeValue == SerializerTypes.XmlSerializer)
            {
                StringReader sww = new StringReader(xmlContent);
                XmlReader reader = XmlReader.Create(sww);
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(instanceType);
                returnValue = serializer.Deserialize(reader);
            }
            else if (serializerTypeValue == SerializerTypes.XmlObjectSerializer)
            {   XmlObjectSerializer serializer = new XmlObjectSerializer();
                returnValue = serializer.Deserialize(xmlContent, true);
            }
            else
            {
                if (instanceType == typeof(string))
                {
                    returnValue = xmlContent;
                }
                else
                {
                    var method = instanceType.GetMethod("Parse", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
                    returnValue = method.Invoke(null, new object[] { xmlContent });
                }
            }
            return returnValue;
        }

        private static void GetSerializerDetails(string serializerType, out SerializerTypes serializerTypeValue, out Type serializedType)
        {
            int index = serializerType.IndexOf(".");
            string serializerTypeValueString = serializerType.Substring(0, serializerType.IndexOf("."));
            string serializedTypeName = serializerType.Substring(index + 1);
                        
            var primitiveType = GetPrimitiveTypeMapping().Where(a=>a.Item2.Equals(serializedTypeName, StringComparison.OrdinalIgnoreCase) || a.Item3.Equals(serializedTypeName, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            if (primitiveType != null)
            {
                serializerTypeValue = SerializerTypes.Primitive;
                return;
            }
            else
            if (serializedTypeName.IsAny(StringComparison.OrdinalIgnoreCase, "int", "string", "double", "float", "long"))
            serializedType = Type.GetType(serializedTypeName);
            serializerTypeValue = (SerializerTypes) Enum.Parse(typeof(SerializerTypes), serializerTypeValueString);
        }

        private static IEnumerable<Tuple<Type, string, string>> GetPrimitiveTypeMapping()
        {
            return (from type in SerializationHelper.primitiveTypes.Value
                    select new Tuple<Type, string, string>(type, type.FullName, type.Name));
        }

        private static bool TryGetPrimitiveType(string typeName, out Type primitiveType)
        {
            if (typeName.StartsWith("System.", StringComparison.OrdinalIgnoreCase))
                primitiveType = SerializationHelper.GetPrimitiveTypeNames(true).Where(a => a.Equals(typeName, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
        }
    }
}
