using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;
using OneParagraph.Shared.Extensions;

namespace OneParagraph.Shared.Enums;
[JsonConverter(typeof(JsonDescriptionToEnumConverter))]
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

public class JsonDescriptionToEnumConverter : JsonConverter<Industries>
{
    public override Industries Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        List<Industries> industriesList = Enum.GetValues<Industries>().ToList();

        foreach (var industry in industriesList)
        {
            if (industry.GetEnumDescription() == reader.GetString()) return industry;
        }

        return Industries.BasicMaterials;
    }

    public override void Write(Utf8JsonWriter writer, Industries value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.GetEnumDescription());
    }
}