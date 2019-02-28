using System;

namespace DevelopmentTest.Repeaters
{
    public class RepeaterItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Medal { get; set; }
        public string Color { get; set; }
        public string Rating { get; set; }
        public DateTime Date { get; set; }
        public string Reason { get; set; }
        public string NameColor { get; set; }
        public string RatingColor { get; set; }
        public string MedalLabel { get; set; }
        public DocumentType DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public bool Status { get; set; }
        public enum Names
        {
            Esmeralda_Olivia_Moutinho,
            Edivaldo_Fernandes_da_Silva,
            Fabiano_Teixeira_da_Costa,
            João_Viana_da_Silva,
            Joshua_Homme,
            Frank_Wright_Third,
            Michael_Pritchard
        }
        public enum Rate
        {
            Ouro,
            Prata,
            Bronze
        }

        public RepeaterItem(int id, string Rate)
        {
            if (Rate == null)
            {

                Rate = "Clock";
            }
            var medal = RandomEnumValue<Rate>();
            var name = RandomEnumValue<Names>();

            var medalString = Rate;
            Rating = medalString;
            if(medalString == "Sem Classificação"){
                medalString = "none";
            }
            MedalLabel = Rating;
            NameColor = "#0099FF";
            RatingColor = "#9E9E9E";
            Status = true;
            switch (medalString)
            {
                case "Ouro":
                    Color = "#F5C523";
                    break;
                case "Prata":
                    Color = "#C4D8DE";
                    break;
                case "Clock":
                    Color = "#0099FF";
                    MedalLabel = "Aguardando resultado";
                    NameColor = "#666666";
                    RatingColor = "#0099FF";
                    Status = false;
                    break;
                default:
                    Color = "#C27377";
                    break;
            }
            Medal = medalString.ToLower() + ".png";
            ID = id;
        }

        public RepeaterItem(int id)
        {
            var medal = RandomEnumValue<Rate>();
            var name = RandomEnumValue<Names>();

            var medalString = medal.ToString();
            switch (medalString)
            {
                case "Ouro":
                    Color = "#F5C523";
                    break;
                case "Prata":
                    Color = "#C4D8DE";
                    break;
                default:
                    Color = "#C27377";
                    break;
            }
            Rating = medalString;
            Medal = medalString.ToLower() + ".png";
            Name = name.ToString().Replace("_", " ");
            Random rand = new Random();
            ID = id;
        }

        static T RandomEnumValue<T>()
        {
            var v = Enum.GetValues(typeof(T));
            return (T)v.GetValue(new Random().Next(v.Length));
        }
    }

}
