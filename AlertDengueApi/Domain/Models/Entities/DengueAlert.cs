using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using AlertDengueApi.Models.Enum;

namespace AlertDengueApi.Models
{
    public class DengueAlert
    {
        [Key]
        public long Id { get; set; } // API numeric ID

        [Required]
        [JsonPropertyName("data_ini_SE")]
        public DateTime StartOfEpiWeek { get; set; } // Primeiro dia da semana epidemiológica

        [JsonPropertyName("SE")]
        public int EpidemiologicalWeek { get; set; }

        public int EpidemiologicalYear { get; set; }

        [JsonPropertyName("casos_est")]
        public double EstimatedCases { get; set; }

        [JsonPropertyName("casos_est_min")]
        public double EstimatedCasesMin { get; set; }

        [JsonPropertyName("casos_est_max")]
        public double EstimatedCasesMax { get; set; }

        [JsonPropertyName("casos")]
        public int ReportedCases { get; set; }

        [JsonPropertyName("p_rt1")]
        public double ProbabilityRtAbove1 { get; set; }

        [JsonPropertyName("p_inc100k")]
        public double IncidencePer100k { get; set; }

        [JsonPropertyName("nivel")]
        public AlertLevel AlertLevel { get; set; }

        [JsonPropertyName("versao_modelo")]
        public string? ModelVersion { get; set; }

        [JsonPropertyName("Rt")]
        public double Rt { get; set; }

        [JsonPropertyName("pop")]
        public double Population { get; set; }

        [JsonPropertyName("tempmin")]
        public double TempMin { get; set; }

        [JsonPropertyName("tempmed")]
        public double TempAvg { get; set; }

        [JsonPropertyName("tempmax")]
        public double TempMax { get; set; }

        [JsonPropertyName("umidmin")]
        public double HumidityMin { get; set; }

        [JsonPropertyName("umidmed")]
        public double HumidityAvg { get; set; }

        [JsonPropertyName("umidmax")]
        public double HumidityMax { get; set; }

        [JsonPropertyName("receptivo")]
        public Receptivity Receptivity { get; set; }

        [JsonPropertyName("transmissao")]
        public Transmission Transmission { get; set; }

        [JsonPropertyName("nivel_inc")]
        public IncidenceLevel IncidenceLevel { get; set; }

        [JsonPropertyName("notif_accum_year")]
        public int AccumulatedNotifications { get; set; }
    }
}