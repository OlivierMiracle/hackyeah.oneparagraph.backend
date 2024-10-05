using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;
using OneParagraph.Shared.Extensions;

namespace OneParagraph.Shared.Enums;
[JsonConverter(typeof(JsonDescriptionToEnumConverter))]
[Flags]
public enum Industry
{
    [Description("Basic Materials")]
    BasicMaterials = 0b0000_0000_0000_0001,

    [Description("Communication Services")]
    CommunicationServices = 0b0000_0000_0000_0010,

    [Description("Consumer Cyclical")]
    ConsumerCyclical = 0b0000_0000_0000_0100,

    [Description("Consumer Defensive")]
    ConsumerDefensive = 0b0000_0000_0000_1000,

    [Description("Consumer Goods")]
    ConsumerGoods = 0b0000_0000_0001_0000,

    [Description("Energy")]
    Energy = 0b0000_0000_0010_0000,

    [Description("Financial")]
    Financial = 0b0000_0000_0100_0000,

    [Description("Financial Services")]
    FinancialServices = 0b0000_0000_1000_0000,

    [Description("Healthcare")]
    Healthcare = 0b0000_0001_0000_0000,

    [Description("Industrial Goods")]
    IndustrialGoods = 0b0000_0010_0000_0000,

    [Description("Industrials")]
    Industrials = 0b0000_0100_0000_0000,

    [Description("Real Estate")]
    RealEstate = 0b0000_1000_0000_0000,

    [Description("Services")]
    Services = 0b0001_0000_0000_0000,

    [Description("Technology")]
    Technology = 0b0010_0000_0000_0000,

    [Description("Utilities")]
    Utilities = 0b0100_0000_0000_0000,

    [Description("N/A")]
    NA = 0b1000_0000_0000_0000,
}

public class JsonDescriptionToEnumConverter : JsonConverter<Industry>
{
    public override Industry Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        List<Industry> industriesList = Enum.GetValues<Industry>().ToList();

        foreach (var industry in industriesList)
        {
            if (industry.GetEnumDescription() == reader.GetString()) return industry;
        }

        return Industry.BasicMaterials;
    }

    public override void Write(Utf8JsonWriter writer, Industry value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.GetEnumDescription());
    }
}