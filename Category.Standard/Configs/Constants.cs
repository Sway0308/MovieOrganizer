using System;

namespace Category.Standard.Configs
{
    public sealed class BaseConstants
    {
        private BaseConstants()
        {
        }

        public static string AppDataPath { get; } = AppDomain.CurrentDomain.BaseDirectory + "App_Data\\";
    }

    public enum CategoryType
    {
        Undefined,
        Distributor,
        Identification,
        ExtraInfo
    }
}
