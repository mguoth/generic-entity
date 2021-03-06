using GenericEntity.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericEntity.Extensions
{
    public static class FieldExtensions
    {
        public static IGetter<string> GetString(this IField field)
        {
            return field.Get<string>();
        }

        public static ISetter<string> SetString(this IField field)
        {
            return field.Set<string>();
        }

        public static IGetter<int> GetInt32(this IField field)
        {
            return field.Get<int>();
        }

        public static ISetter<int> SetInt32(this IField field)
        {
            return field.Set<int>();
        }

        private static IGetter<T> Get<T>(this IField field)
        {
            IGetter<T> getter = field as IGetter<T>;
            if (getter != null)
            {
                return getter;
            }
            return new NotSupportedGetter<T>(field);
        }

        private static ISetter<T> Set<T>(this IField field)
        {
            ISetter<T> setter = field as ISetter<T>;
            if (setter != null)
            {
                return setter;
            }
            return new NotSupportedSetter<T>(field);
        }
    }
}
