using System;
using System.ComponentModel;
using System.Reflection;

namespace WpfApp6.Enums {
    public enum PackageStatus {
        [Description("Przesyłka jest przetwarzana")]
        InProgress,
        [Description("w Drodze")]
        Sent,
        [Description("W rękach kuriera")]
        ReceivedByCourier,
        [Description("Dostarczona")]
        Delivered
    }

    public static class PackageStatusExtensions {
        public static string GetDescription<T>(this T enumerationValue)
            where T : struct {
                Type type = enumerationValue.GetType();
                if (!type.IsEnum) {
                    throw new ArgumentException("EnumerationValue must be of Enum type", "enumerationValue");
                }

                MemberInfo[] memberInfo = type.GetMember(enumerationValue.ToString());
                if (memberInfo != null && memberInfo.Length > 0) {
                    object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                    if (attrs != null && attrs.Length > 0) {
                        return ((DescriptionAttribute)attrs[0]).Description;
                    }
                }

                return enumerationValue.ToString();
        }
    }
}
