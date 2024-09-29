using System.ComponentModel;

namespace OneParagraph.Shared.Enums;

public enum Industries
{
    [Description("Basic Materials")]
    BasicMaterials,

    [Description("Communication Services")]
    CommunicationServices,

    [Description("Consumer Cyclical")]
    ConsumerCyclical,

    [Description("Consumer Defensive")]
    ConsumerDefensive,

    [Description("Consumer Goods")]
    ConsumerGoods,

    [Description("Energy")]
    Energy,

    [Description("Financial")]
    Financial,

    [Description("Financial Services")]
    FinancialServices,

    [Description("Healthcare")]
    Healthcare,

    [Description("Industrial Goods")]
    IndustrialGoods,

    [Description("Industrials")]
    Industrials,

    [Description("Real Estate")]
    RealEstate,

    [Description("Services")]
    Services,

    [Description("Technology")]
    Technology,

    [Description("Utilities")]
    Utilities,

    [Description("N/A")]
    NA
}