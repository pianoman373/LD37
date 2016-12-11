using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;

public class json : MonoBehaviour {

	public static int[,] loadMap(string path) {
		string fileData = readFile ("maps/"+path);
		if (fileData != null) { 
			JSONObject json = new JSONObject (fileData);
			JSONObject layers = json.list[json.keys.IndexOf("layers")];
			int[,] output = new int[(int)layers.list [0] [1].n, (int)layers.list [0] [1].n];
			int x = 0;
			int z = 0;
			foreach (JSONObject i in layers.list[0][0].list) {
				print (((string)x.ToString())+"-"+((string)z.ToString()));;
				output[x,z] = (int)i.n;
					z += 1;
				if (z == (int)layers.list [0] [1].n) {
					z = 0;
					x += 1;
				}
			}
			print (layers.list[1][3]);
			return output;
			/*
			foreach (JSONObject j in layers.list) {
				for(int i = 0; i < j.Count;i++){
					print(j[i]);
				}
			}
/*
			int length = 20;//int.Parse(list[keys.IndexOf("height")].str);
			int[,] data = new int[length, length];
			for (int i = 0;i < keys.Count;i++) {
				if (keys[i] == "data") {
					int index = 0;
					int index2 = 0;
					foreach(JSONObject j in list[i].list){
						data [index2, index] = int.Parse(j.str);
						index += 1;
						if (index == length - 1) {
							index2 += 1;
						}
					}
				}
			}*/
			//return data;
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
