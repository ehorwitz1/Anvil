namespace Mapbox.Unity.Map
{
	using UnityEngine;
	using Mapbox.Map;

	public class AccessableRangeTileProvider : AbstractTileProvider
	{
		[SerializeField]
		private int _west;
		[SerializeField]
		private int _north;
		[SerializeField]
		private int _east;
		[SerializeField]
		private int _south;

		public Vector4 getTileCounts(){
			return new Vector4( _west, _north, _east, _south );
		}

		public override void OnInitialized()
		{
			var centerTile = TileCover.CoordinateToTileId(_map.CenterLatitudeLongitude, _map.AbsoluteZoom);
			AddTile(new UnwrappedTileId(_map.AbsoluteZoom, centerTile.X, centerTile.Y));
			for (int x = (int)(centerTile.X - _west); x <= (centerTile.X + _east); x++)
			{
				for (int y = (int)(centerTile.Y - _north); y <= (centerTile.Y + _south); y++)
				{
					AddTile(new UnwrappedTileId(_map.AbsoluteZoom, x, y));
				}
			}
		}
	}
}
