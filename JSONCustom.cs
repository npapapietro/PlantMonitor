using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Collections.ObjectModel;

namespace PlantMonitor
{
    public class PlantObjSerializer : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(PlantObj).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jsonobj = JObject.Load(reader);
            var properties = jsonobj.Properties().ToList();
            
            var loaded = new PlantObj
            {
                Name = (string)properties[0].Value,
                get_internalID = (string)properties[1].Value,
                moved = properties[2].Value.Select(t => (DateTime)t).ToArray(),
                currentsize = bucketdeserializer((string)properties[3].Value),
                my_position = properties[4].Value.Select(t => (int)t).ToArray(),
                cuts = new ObservableCollection<CutDetails>(properties[5].Value.Select(t => JsonConvert.DeserializeObject<CutDetails>(t.ToString())).ToArray())
            };

            loaded.loadPlantObj();
            loaded.updateCanvasObjs();
            return loaded;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var obj = value as PlantObj;

            writer.WriteStartObject();
            writer.WritePropertyName("PlantObj.Name");
            serializer.Serialize(writer, obj.Name);

            writer.WritePropertyName("PlantObj.get_internalID");
            serializer.Serialize(writer, obj.get_internalID);

            writer.WritePropertyName("PlantObj.moved");
            writer.WriteStartArray();
            foreach (var i in obj.moved) { serializer.Serialize(writer, i); }
            writer.WriteEndArray();

            writer.WritePropertyName("PlantObj.currentsize");
            serializer.Serialize(writer, obj.currentsize);

            writer.WritePropertyName("PlantObj.my_position");
            writer.WriteStartArray();
            foreach (var i in obj.my_position) { serializer.Serialize(writer, i); }
            writer.WriteEndArray();

            writer.WritePropertyName("PlantObj.cuts");
            writer.WriteStartArray();
            foreach (var i in obj.cuts) { serializer.Serialize(writer, i); }
            writer.WriteEndArray();
            
            writer.WriteEndObject();
        }

        private PlantObj.BucketSize bucketdeserializer(string bucketsizechoice)
        {
            switch (bucketsizechoice)
            {
                case "0":
                    return PlantObj.BucketSize.nogal;
                case "1":
                    return PlantObj.BucketSize.onegal;
                case "2":
                    return PlantObj.BucketSize.threegal;
                case "3":
                    return PlantObj.BucketSize.sevengal;
                default:
                    return PlantObj.BucketSize.nogal;
            }
        }
    };


}