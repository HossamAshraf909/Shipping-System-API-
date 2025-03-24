using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.DAL.Persistent.Enums
{
    public enum ShippingMethod
    {
        FromCompanyBranch = 1, FromMerchentBranch = 2
    }

    public enum OrderStatus
    {
        New = 1,
        Pending = 2,
        Delivered = 3,
        PartiallyDelivered = 4,
        CanceledByRecipient = 5,
        Rejected = 6,
        PaymentPending = 7,
        CannotBeReached = 8,
        Processing = 9,
        Shipped = 10,
        AwaitingConfirmation = 11
    }

    public enum PaymentMethod
    {
        Cash = 1, Credit = 2, Order = 3
    }

    public enum RejectionReason
    {
        CustomerChangedMind = 1,
        ProductDamaged = 2,
        WrongItemReceived = 3,
        DelayedDelivery = 4,
        HighPrice = 5,
        FoundBetterAlternative = 6,
        PaymentIssue = 7,
        OrderPlacedByMistake = 8,
        CustomerUnavailable = 9,
        Other = 10
    }




}
