namespace bcwGregsListCS.Enums;

using System.Text.Json.Serialization;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ListingType {
  Car,
  House,
  Job
}