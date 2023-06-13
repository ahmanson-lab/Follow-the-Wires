using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class hyperlink :  MonoBehaviour, IPointerClickHandler
{
	public Camera Viewcamera;
	/* public void OnPointerClick(PointerEventData eventData)
	 {
		 TMP_Text pTextMeshPro = GetComponent<TMP_Text> ();
		 int linkIndex = TMP_TextUtilities.FindIntersectingLink(pTextMeshPro, eventData.position, null);  // If you are not in a Canvas using Screen Overlay, put your camera instead of null
		 if (linkIndex != -1)
		 { // was a link clicked?
			 TMP_LinkInfo linkInfo = pTextMeshPro.textInfo.linkInfo[linkIndex];
			 Application.OpenURL(linkInfo.GetLinkID());
		 }
	 }*/

	// URLs to open when links clicked
	private const string projectLink = "https://polymathic.usc.edu/ahmanson-lab/firescapes-powerlines-trees-collaboratory";
	private const string AhmansonLabLink = "https://polymathic.usc.edu/ahmanson-lab";
	private const string CaliforniaElectricTransmissionLines = "https://www.arcgis.com/home/item.html?id=260b4513acdb4a3a8e4d64e69fc84fee";
	private const string CaliforniaElectricinformationLink = "https://services3.arcgis.com/bWPjFyq029ChCGur/arcgis/rest/services/Transmission_Line/FeatureServer";
	private const string WildfireMapLink = "https://www.arcgis.com/home/item.html?id=e3802d2abf8741a187e73a9db49d68fe";
	private const string WildfireInfoLink = "https://services1.arcgis.com/jUJYIo9tSA7EHvfZ/arcgis/rest/services/California_Fire_Perimeters/FeatureServer";
	private const string StateReport = "https://www.auditor.ca.gov/reports/2021-117/index.html";
	private const string UtilityFire = "https://www.auditor.ca.gov/reports/2021-117/supplemental-fire-incident.html";
	private const string Frank = "https://commons.wikimedia.org/wiki/User:Frank_Schulenburg";
	private const string Landsat = "https://www.usgs.gov/media/images/landsat-after-dixie-fire-ca-august-12-2021";
	private const string AmericanProgressLink = "https://commons.wikimedia.org/wiki/File:American_Progress_(John_Gast_painting).jpg";
	private const string EdisonCompanyLink = "https://www.davidrumsey.com/luna/servlet/detail/RUMSEY~8~1~274154~90047930:A-Pictorial-Map-of-the-Edison-Elect?sort=Pub_List_No_InitialSort%2CPub_Date%2CPub_List_No%2CSeries_No&qvq=q:A%20Pictorial%20Map%20of%20the%20Edison%20Electrical%20Service%20System%20in%20Central%20and%20Southern%20California;sort:Pub_List_No_InitialSort%2CPub_Date%2CPub_List_No%2CSeries_No;lc:RUMSEY~8~1&mi=0&trs=1";
	private const string EdisonCompanyLink2 = "https://www.davidrumsey.com/luna/servlet/detail/RUMSEY~8~1~271932~90045781:Southern-California-Edison-Company-#";
	private const string IndianLink = "https://iltf.org/";
	private const string DefaultUrl = "https://polymathic.usc.edu/ahmanson-lab/firescapes-powerlines-trees-collaboratory";

	[SerializeField, Tooltip("The UI GameObject having the TextMesh Pro component.")]
	private TMP_Text text = default;

	
    // Callback for handling clicks.
    public void OnPointerClick(PointerEventData eventData)
	{
		// First, get the index of the link clicked. Each of the links in the text has its own index.
		var linkIndex = TMP_TextUtilities.FindIntersectingLink(text, Input.mousePosition, Viewcamera);// If you are not in a Canvas using Screen Overlay, put your camera instead of null

		// As the order of the links can vary easily (e.g. because of multi-language support),
		// you need to get the ID assigned to the links instead of using the index as a base for our decisions.
		// you need the LinkInfo array from the textInfo member of the TextMesh Pro object for that.
		var linkId = text.textInfo.linkInfo[linkIndex].GetLinkID();

		// Now finally you have the ID in hand to decide what to do. Don't forget,
		// you don't need to make it act like an actual link, instead of opening a web page,
		// any kind of functions can be called.
		var url = linkId switch
		{
			"projectLink" => projectLink,
			"AhmansonLab" => AhmansonLabLink,
			"TransmissionLinesMap" => CaliforniaElectricTransmissionLines,
			"TransmissionLinesInfo" => CaliforniaElectricinformationLink,
			"WildfireMap" => WildfireMapLink,
			"WildfireInfo" => WildfireInfoLink,
			"StateReport" => StateReport,
			"UtilityFire" => UtilityFire,
			"Frank" => Frank,
			"Landsat" => Landsat,
			"AmericanProgress" => AmericanProgressLink,
			"EdisonCompany" => EdisonCompanyLink,
			"EdisonCompany2" => EdisonCompanyLink2,
			"Indian" => IndianLink,
			_=> DefaultUrl
		};

		Debug.Log($"URL clicked: linkInfo[{linkIndex}].id={linkId}   ==>   url={url}");

		// Let's see that web page!
		Application.OpenURL(url);
	}

}
