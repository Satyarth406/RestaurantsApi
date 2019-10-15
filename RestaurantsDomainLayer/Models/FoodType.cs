using System;

namespace AuthorizationAndAuthorizationLibrary.Model
{
    [Flags]
    public enum FoodType
    {
        None=0,
        NorthIndian=1,
        Chinese = 2,
        American = 4,
        Desserts=8,
        Salads=16
    }
}