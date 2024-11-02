namespace RavindraInfratch.Models
{
	public class BlockModel
	{
		public int Id { get; set; }

		public string? BlockName { get; set; }
		public List<BlockModel> BlockListModel { get; set; }
	}
}
