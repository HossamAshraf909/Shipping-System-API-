using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shipping.DAL.Persistent.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ShippingMethod
    {
        FromCompanyBranch = 1, FromMerchentBranch = 2
    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OrderStatus
    {
        New = 1, //جديد
        Pending = 2, // قيد الانتظار
        Delivered = 3, // تم التسليم لمندوب
        PartiallyDelivered = 4,// تم التسليم جزئيا 
        CanceledByRecipient = 5,// تم الالغاء من قبل المستلم
        Rejected = 6, // تم الرفض
        Delayed = 7, // تم التأجيل
        CannotBeReached = 8, // لا يمكن الوصول
        rejectedWithPaid = 9,// تم الرفض مع الدفع
        Shipped = 10, // تم الشحن
        rejectedNotPaid = 11, // تم الرفض بدون دفع
        All = 12 // الكل
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PaymentMethod
    {
        Cash = 1, Credit = 2, Order = 3
    }
    [JsonConverter(typeof(JsonStringEnumConverter))]

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
