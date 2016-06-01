using Android.Widget;



using Android.Content;
using Java.Lang;
using Android.Views;
using TestPPMobile;
using Android.Util;

public class MyGridView : GridView {

	public MyGridView(Context context) : base(context) 
	{

	}

	public MyGridView(Context context, IAttributeSet  attrs) : base(context, attrs) 
	{
		
	}

	public MyGridView(Context context, IAttributeSet  attrs, int defStyle) : base (context, attrs, defStyle)
	{
	}

	protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec) {
		int heightSpec;
		GridView tv = (GridView) FindViewById(Resource.Id.gridview);
		var param = (RelativeLayout.LayoutParams)tv.LayoutParameters;
		if (param.Height == LayoutParams.WrapContent) {
			// The great Android "hackatlon", the love, the magic.
			// The two leftmost bits in the height measure spec have
			// a special meaning, hence we can't use them to describe height.
			heightSpec = MeasureSpec.MakeMeasureSpec(Integer.MaxValue >> 2,MeasureSpecMode.AtMost);
		} else {
			heightSpec = heightMeasureSpec;
		}

		this.OnMeasure(widthMeasureSpec, heightSpec);
	}


}