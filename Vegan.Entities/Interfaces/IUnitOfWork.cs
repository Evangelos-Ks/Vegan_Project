using System;
using Vegan.Entities.Interfaces.CareInterfaces;
using Vegan.Entities.Interfaces.FoodInterfaces;
using Vegan.Entities.Interfaces.HomeInterfaces;
using Vegan.Entities.Interfaces.SupplementInterfaces;

namespace Vegan.Entities.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICare Cares { get; }
        IFaceCream FaceCreams { get; }
        IHair Hairs { get; }
        ILotion Lotions { get; }
        IShaveBeard ShaveBeards { get; }
        IFoodHerb FoodHerbs { get; }
        ISalt Salts { get; }
        ISpice Spices { get; }
        ISproutingSeed SproutingSeeds { get; }
        ITea Teas { get; }
        ICandle Candles { get; }
        IEssentialOil EssentialOils { get; }
        IHome Homes { get; }
        IHomeCleaning HomeCleanings { get; }
        IKitchen Kitchens { get; }
        IPowerHealth PowerHealths { get; }
        ISuperFood SuperFoods { get; }
        ISupplement Supplements { get; }
        IOrder Orders { get; }
        IProduct Products { get; }
        IUser Users { get; }

        int Complete();
    }
}
