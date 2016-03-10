using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CSVReader {

	private List<List<string>> _data;
	public List<List<string>> data{
		get {return _data;}
	}

	private string _text;

	public CSVReader(string assetName){
		TextAsset asset = Resources.Load<TextAsset>(assetName);

		if (asset != null) {
			_text = asset.text;
			init();
		}

	}

	private void init(){
		string[] rows = _text.Split(new char[] {'\n'});

		int i, j;

		_data = new List<List<string>>();
		for (i = 0; i < rows.Length; i++) {
			string[] cols = rows[i].Split(new char[] {'\t'});

			_data.Add(new List<string>());
			for (j = 0; j < cols.Length; j++){
				_data[i].Add (cols[j]);
				int p;
				while( (p = _data[i][j].LastIndexOf("\n")) >= 0 ){
					_data[i][j] = _data[i][j].Substring(0, p);
				}
				while( (p = _data[i][j].LastIndexOf("\r")) >= 0 ){
					_data[i][j] = _data[i][j].Substring(0, p);
				}
			}
		}

		for (i = 0; i < _data.Count; i++) {
			for (j = 0; j < _data[i].Count; j++){
				_data[i][j] = _data[i][j].Replace("\\n", "\n");
				_data[i][j] = _data[i][j].Replace("\\t", "\t");
			}
		}
	}
}
