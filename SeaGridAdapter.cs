using System;
namespace BattleShips
{


	public class SeaGridAdapter : ISeaGrid
	{
		private SeaGrid _myGrid;


		public SeaGridAdapter (SeaGrid grid)
		{
			_myGrid = grid;
			_myGrid.Changed += new EventHandler (MyGrid_Changed);

			//Changed += new EventHandler (GameController.GridChanged);
		}


		private void MyGrid_Changed (object sender, EventArgs e)
		{
			Changed (this, e);
		}


		public TileView this [int x, int y] {
			get {
				TileView result = _myGrid [x, y];

				if (result == TileView.Ship) {
					return TileView.Sea;
				} else {
					return result;
				}
			}
		}


		public event EventHandler Changed;


		public int Width {
			get {
				return _myGrid.Width;
			}
		}

		public int Height {
			get {
				return _myGrid.Height;
			}
		}


		public AttackResult HitTile (int row, int col)
		{
			return _myGrid.HitTile (row, col);
		}

	}
}