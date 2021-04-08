using System.Xml.Serialization;

namespace MusicHub.DataProcessor.ImportDtos
{
    [XmlType("Song")]
    public class ImportPerfomerSongsDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
