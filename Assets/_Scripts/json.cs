using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;

public class json : MonoBehaviour {
	public static Dictionary<string,int[,]> maps = new Dictionary<string,int[,]>();

	public static int[,] loadMap(string path) {
		string fileData = readFile ("maps/"+path);
		if (fileData != null) { 
			JSONObject json = new JSONObject (fileData);
			JSONObject layers = json.list[json.keys.IndexOf("layers")];
			int[,] output = new int[(int)layers.list [0] [1].n, (int)layers.list [0] [1].n];
			int x = 0;
			int z = 0;
			foreach (JSONObject i in layers.list[0][0].list) {
				output[x,z] = (int)i.n;
					z += 1;
				if (z == (int)layers.list [0] [1].n) {
					z = 0;
					x += 1;
				}
			}
			foreach (JSONObject i in layers.list[1][3].list){
				if (i.list [i.keys.IndexOf ("type")].str == "wall") {
					output [((int)i.list [i.keys.IndexOf ("y")].n / 16)-1, ((int)i.list [i.keys.IndexOf ("x")].n / 16)] = 2;
				}else if (i.list [i.keys.IndexOf ("type")].str == "cube") {
					JSONObject properties = i.list [i.keys.IndexOf ("properties")];
					output [((int)i.list [i.keys.IndexOf ("y")].n / 16)-1, ((int)i.list [i.keys.IndexOf ("x")].n / 16)] = 100+int.Parse(properties.list[properties.keys.IndexOf ("color")].str);
				}
			}
			return output;
		}
		return null;
	}

	static string readFile(string path){
		string output = "";
		try {
			string line;
			StreamReader theReader = new StreamReader (path, Encoding.Default);
			using (theReader) {
				do {
					line = theReader.ReadLine ();
					if (line != null) {
						output += line;
					}
				} while (line != null);   
				theReader.Close ();
				return output;
			}
		} catch (System.Exception e) {
			print ("{0}\n" + e.Message);
		}
		return null;
	}
}
