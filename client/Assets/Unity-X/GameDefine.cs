
public enum LoadingStep
{
	None,
	Login,
	Data,
	Main,
	Count,
}

public class AssetsPath
{
	public const string Configs = "Configs/";
	public const string Localizations = "Localizations/";
	public const string ItemSpritePath = "Sprites/Element/";
}

public class GameDefine
{
	public const bool IsCheckConfigsValid = true;

	public const int SHAKE_PRICE_CORRECT = 5;
	public const float RECIPE_RATIO_MULTI = 0.1f;
}

public class TowerDefine
{
	public const int ROW_NUM = 6;
	public const int COL_NUM = 6;
	public const float TILE_WIDTH = 0.5f;
	public const float TILE_HALE_WIDTH = TILE_WIDTH * 0.5f;
}
