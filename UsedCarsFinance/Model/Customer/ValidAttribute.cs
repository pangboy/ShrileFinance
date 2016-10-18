using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Customer
{
    /// <summary>
    /// N类型验证特性
    /// </summary>
    /// zouql   16.10.17
    public class NAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var temp = value.ToString();
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] < 0X30 || temp[i] > 0X39)
                {
                    return false;
                }
            }
            return true;
        }
    }

    /// <summary>
    /// AN类型验证特性
    /// </summary>
    /// zouql   16.10.17
    public class ANAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var temp = value.ToString();
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] < 0X20 || temp[i] > 0X7E)
                {
                    return false;
                }
            }

            return false;
        }
    }

    /// <summary>
    /// ANC类型验证特性
    /// </summary>
    /// zouql   16.10.17
    public class ANCAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return true;
        }
    }
}