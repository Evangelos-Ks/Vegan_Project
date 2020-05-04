using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vegan.Entities.Interfaces.CareInterfaces;
using Vegan.Entities.Interfaces.FoodInterfaces;
using Vegan.Entities.Interfaces.HomeInterfaces;
using Vegan.Entities.Interfaces.SupplementInterfaces;

namespace Vegan.Entities.Interfaces
{
    interface IUnitOfWork : IDisposable
    {
        ICare Care { get; }
        IFaceCream FaceCream { get; }
        IHair Hair { get; }
        ILotion Lotion { get; }
        IShaveBeard ShaveBeard { get; }
        IFoodHearb FoodHearb { get; }
        ISalt Salt { get; }
        ISpice Spice { get; }
        ISproutingSeed SproutingSeed { get; }
        ITea Tea { get; }
        ICandle Candle { get; }
        IEssentialOil EssentialOil { get; }
        IHome Home { get; }
        IHomeCleaning HomeCleaning { get; }
        IKitchen Kitchen { get; }
        IPowerHealth PowerHealth { get; }
        ISuperFood SuperFood { get; }
        ISupplement Supplement { get; }
        IOrder Order { get; }
        IProduct Product { get; }

        int Complete();
    }
}
