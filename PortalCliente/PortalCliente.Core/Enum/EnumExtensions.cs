using System.ComponentModel;

namespace PortalCliente.Core.Enum
{
    public static class EnumExtensions
    {
        public static string GetDescription(this System.Enum enumValue)
        {
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
            var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : enumValue.ToString();
        }
    }
}
