﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;

public class json : MonoBehaviour {
	public static Dictionary<string,int[,]> maps = new Dictionary<string,int[,]>();
	public static Dictionary<string,List<Vector4>> groups = new Dictionary<string,List<Vector4>>();
	public static Dictionary<string, string> filesData = new Dictionary<string, string> ();

	public static void Start(){
		filesData.Add ("tutorial.json","{ \"height\":20, \"layers\":[ { \"data\":[2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 4, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2], \"height\":20, \"name\":\"Tile Layer 1\", \"opacity\":1, \"type\":\"tilelayer\", \"visible\":true, \"width\":20, \"x\":0, \"y\":0 }, { \"draworder\":\"topdown\", \"height\":0, \"name\":\"objects\", \"objects\":[ { \"gid\":6, \"height\":16, \"id\":41, \"name\":\"wall 1\", \"properties\": { \"group\":\"1\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":112, \"y\":112 }, { \"gid\":5, \"height\":16, \"id\":43, \"name\":\"button 1\", \"properties\": { \"color\":\"1\", \"group\":\"1\" }, \"propertytypes\": { \"color\":\"string\", \"group\":\"string\" }, \"rotation\":0, \"type\":\"button\", \"visible\":true, \"width\":16, \"x\":80, \"y\":112 }, { \"gid\":6, \"height\":16, \"id\":47, \"name\":\"wall 1\", \"properties\": { \"group\":\"1\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":112, \"y\":128 }, { \"gid\":6, \"height\":16, \"id\":48, \"name\":\"wall 1\", \"properties\": { \"group\":\"1\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":96, \"y\":128 }, { \"gid\":7, \"height\":16, \"id\":49, \"name\":\"cube\", \"properties\": { \"color\":\"2\" }, \"propertytypes\": { \"color\":\"string\" }, \"rotation\":0, \"type\":\"cube\", \"visible\":true, \"width\":16, \"x\":192, \"y\":272 }, { \"gid\":5, \"height\":16, \"id\":52, \"name\":\"button 2\", \"properties\": { \"color\":\"2\", \"group\":\"2\" }, \"propertytypes\": { \"color\":\"string\", \"group\":\"string\" }, \"rotation\":0, \"type\":\"button\", \"visible\":true, \"width\":16, \"x\":224, \"y\":288 }, { \"gid\":7, \"height\":16, \"id\":53, \"name\":\"cube\", \"properties\": { \"color\":\"1\" }, \"propertytypes\": { \"color\":\"string\" }, \"rotation\":0, \"type\":\"cube\", \"visible\":true, \"width\":16, \"x\":64, \"y\":112 }, { \"gid\":6, \"height\":16, \"id\":54, \"name\":\"wall 2\", \"properties\": { \"group\":\"2\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":256, \"y\":272 }, { \"gid\":6, \"height\":16, \"id\":55, \"name\":\"wall 2\", \"properties\": { \"group\":\"2\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":272, \"y\":272 }, { \"gid\":6, \"height\":16, \"id\":84, \"name\":\"wall 2\", \"properties\": { \"group\":\"2\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":256, \"y\":288 }], \"opacity\":1, \"type\":\"objectgroup\", \"visible\":true, \"width\":0, \"x\":0, \"y\":0 }], \"nextobjectid\":85, \"orientation\":\"orthogonal\", \"renderorder\":\"right-down\", \"tileheight\":16, \"tilesets\":[ { \"columns\":4, \"firstgid\":1, \"image\":\"tilemap.png\", \"imageheight\":64, \"imagewidth\":64, \"margin\":0, \"name\":\"tilemap\", \"spacing\":0, \"tilecount\":16, \"tileheight\":16, \"tileproperties\": { \"4\": { \"color\":\"1\", \"group\":\"1\" }, \"5\": { \"group\":\"1\", \"inverted\":false }, \"6\": { \"color\":\"1\" } }, \"tilepropertytypes\": { \"4\": { \"color\":\"string\", \"group\":\"string\" }, \"5\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"6\": { \"color\":\"string\" } }, \"tilewidth\":16 }], \"tilewidth\":16, \"version\":1, \"width\":20 }");
		filesData.Add ("level1.json","{ \"height\":20, \"layers\":[ { \"data\":[2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 4, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2], \"height\":20, \"name\":\"Tile Layer 1\", \"opacity\":1, \"type\":\"tilelayer\", \"visible\":true, \"width\":20, \"x\":0, \"y\":0 }, { \"draworder\":\"topdown\", \"height\":0, \"name\":\"objects\", \"objects\":[ { \"gid\":6, \"height\":16, \"id\":41, \"name\":\"wall 1\", \"properties\": { \"group\":\"3\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":112, \"y\":144 }, { \"gid\":5, \"height\":16, \"id\":43, \"name\":\"button 1\", \"properties\": { \"color\":\"3\", \"group\":\"3\" }, \"propertytypes\": { \"color\":\"string\", \"group\":\"string\" }, \"rotation\":0, \"type\":\"button\", \"visible\":true, \"width\":16, \"x\":192, \"y\":160 }, { \"gid\":6, \"height\":16, \"id\":47, \"name\":\"wall 1\", \"properties\": { \"group\":\"3\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":112, \"y\":160 }, { \"gid\":6, \"height\":16, \"id\":48, \"name\":\"wall 1\", \"properties\": { \"group\":\"3\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":112, \"y\":48 }, { \"gid\":7, \"height\":16, \"id\":49, \"name\":\"cube\", \"properties\": { \"color\":\"2\" }, \"propertytypes\": { \"color\":\"string\" }, \"rotation\":0, \"type\":\"cube\", \"visible\":true, \"width\":16, \"x\":256, \"y\":240 }, { \"gid\":5, \"height\":16, \"id\":52, \"name\":\"button 2\", \"properties\": { \"color\":\"2\", \"group\":\"2\" }, \"propertytypes\": { \"color\":\"string\", \"group\":\"string\" }, \"rotation\":0, \"type\":\"button\", \"visible\":true, \"width\":16, \"x\":224, \"y\":160 }, { \"gid\":7, \"height\":16, \"id\":53, \"name\":\"cube\", \"properties\": { \"color\":\"3\" }, \"propertytypes\": { \"color\":\"string\" }, \"rotation\":0, \"type\":\"cube\", \"visible\":true, \"width\":16, \"x\":224, \"y\":240 }, { \"gid\":6, \"height\":16, \"id\":54, \"name\":\"wall 2\", \"properties\": { \"group\":\"2\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":160, \"y\":192 }, { \"gid\":6, \"height\":16, \"id\":55, \"name\":\"wall 2\", \"properties\": { \"group\":\"2\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":160, \"y\":144 }, { \"gid\":6, \"height\":16, \"id\":84, \"name\":\"wall 2\", \"properties\": { \"group\":\"2\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":160, \"y\":288 }, { \"gid\":5, \"height\":16, \"id\":85, \"name\":\"button 3\", \"properties\": { \"color\":\"4\", \"group\":\"4\" }, \"propertytypes\": { \"color\":\"string\", \"group\":\"string\" }, \"rotation\":0, \"type\":\"button\", \"visible\":true, \"width\":16, \"x\":256, \"y\":160 }, { \"gid\":7, \"height\":16, \"id\":86, \"name\":\"cube\", \"properties\": { \"color\":\"4\" }, \"propertytypes\": { \"color\":\"string\" }, \"rotation\":0, \"type\":\"cube\", \"visible\":true, \"width\":16, \"x\":192, \"y\":240 }, { \"gid\":6, \"height\":16, \"id\":87, \"name\":\"wall 1\", \"properties\": { \"group\":\"3\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":112, \"y\":192 }, { \"gid\":6, \"height\":16, \"id\":88, \"name\":\"wall 1\", \"properties\": { \"group\":\"3\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":112, \"y\":208 }, { \"gid\":6, \"height\":16, \"id\":89, \"name\":\"wall 1\", \"properties\": { \"group\":\"3\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":112, \"y\":224 }, { \"gid\":6, \"height\":16, \"id\":90, \"name\":\"wall 1\", \"properties\": { \"group\":\"3\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":112, \"y\":256 }, { \"gid\":6, \"height\":16, \"id\":91, \"name\":\"wall 1\", \"properties\": { \"group\":\"3\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":112, \"y\":272 }, { \"gid\":6, \"height\":16, \"id\":92, \"name\":\"wall 1\", \"properties\": { \"group\":\"3\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":112, \"y\":288 }, { \"gid\":6, \"height\":16, \"id\":94, \"name\":\"wall 1\", \"properties\": { \"group\":\"3\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":112, \"y\":96 }, { \"gid\":6, \"height\":16, \"id\":95, \"name\":\"wall 1\", \"properties\": { \"group\":\"3\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":112, \"y\":112 }, { \"gid\":6, \"height\":16, \"id\":96, \"name\":\"wall 1\", \"properties\": { \"group\":\"3\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":112, \"y\":128 }, { \"gid\":6, \"height\":16, \"id\":97, \"name\":\"wall 2\", \"properties\": { \"group\":\"2\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":160, \"y\":160 }, { \"gid\":6, \"height\":16, \"id\":98, \"name\":\"wall 2\", \"properties\": { \"group\":\"2\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":160, \"y\":176 }, { \"gid\":6, \"height\":16, \"id\":99, \"name\":\"wall 2\", \"properties\": { \"group\":\"2\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":160, \"y\":128 }, { \"gid\":6, \"height\":16, \"id\":100, \"name\":\"wall 2\", \"properties\": { \"group\":\"2\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":160, \"y\":112 }, { \"gid\":6, \"height\":16, \"id\":101, \"name\":\"wall 2\", \"properties\": { \"group\":\"2\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":160, \"y\":96 }, { \"gid\":6, \"height\":16, \"id\":102, \"name\":\"wall 2\", \"properties\": { \"group\":\"2\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":160, \"y\":80 }, { \"gid\":6, \"height\":16, \"id\":103, \"name\":\"wall 2\", \"properties\": { \"group\":\"2\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":160, \"y\":64 }, { \"gid\":6, \"height\":16, \"id\":104, \"name\":\"wall 2\", \"properties\": { \"group\":\"2\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":160, \"y\":48 }, { \"gid\":6, \"height\":16, \"id\":105, \"name\":\"wall 2\", \"properties\": { \"group\":\"2\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":160, \"y\":256 }, { \"gid\":6, \"height\":16, \"id\":106, \"name\":\"wall 2\", \"properties\": { \"group\":\"2\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":160, \"y\":240 }, { \"gid\":6, \"height\":16, \"id\":107, \"name\":\"wall 2\", \"properties\": { \"group\":\"2\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":160, \"y\":224 }, { \"gid\":6, \"height\":16, \"id\":108, \"name\":\"wall 2\", \"properties\": { \"group\":\"2\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":160, \"y\":208 }, { \"gid\":6, \"height\":16, \"id\":109, \"name\":\"wall 2\", \"properties\": { \"group\":\"2\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":160, \"y\":272 }, { \"gid\":6, \"height\":16, \"id\":110, \"name\":\"wall 1\", \"properties\": { \"group\":\"3\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":112, \"y\":240 }, { \"gid\":6, \"height\":16, \"id\":111, \"name\":\"wall 1\", \"properties\": { \"group\":\"3\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":112, \"y\":176 }, { \"gid\":6, \"height\":16, \"id\":112, \"name\":\"wall 1\", \"properties\": { \"group\":\"3\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":112, \"y\":64 }, { \"gid\":6, \"height\":16, \"id\":113, \"name\":\"wall 1\", \"properties\": { \"group\":\"3\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":112, \"y\":80 }, { \"gid\":6, \"height\":16, \"id\":114, \"name\":\"wall 3\", \"properties\": { \"group\":\"4\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":48, \"y\":288 }, { \"gid\":6, \"height\":16, \"id\":115, \"name\":\"wall 3\", \"properties\": { \"group\":\"4\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":32, \"y\":272 }, { \"gid\":6, \"height\":16, \"id\":116, \"name\":\"wall 3\", \"properties\": { \"group\":\"4\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":48, \"y\":272 }], \"opacity\":1, \"type\":\"objectgroup\", \"visible\":true, \"width\":0, \"x\":0, \"y\":0 }], \"nextobjectid\":117, \"orientation\":\"orthogonal\", \"renderorder\":\"right-down\", \"tileheight\":16, \"tilesets\":[ { \"columns\":4, \"firstgid\":1, \"image\":\"../Assets/tiled/tilemap.png\", \"imageheight\":64, \"imagewidth\":64, \"margin\":0, \"name\":\"tilemap\", \"spacing\":0, \"tilecount\":16, \"tileheight\":16, \"tileproperties\": { \"4\": { \"color\":\"1\", \"group\":\"1\" }, \"5\": { \"group\":\"1\", \"inverted\":false }, \"6\": { \"color\":\"1\" } }, \"tilepropertytypes\": { \"4\": { \"color\":\"string\", \"group\":\"string\" }, \"5\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"6\": { \"color\":\"string\" } }, \"tilewidth\":16 }], \"tilewidth\":16, \"version\":1, \"width\":20 }");
		filesData.Add ("level2.json","{ \"height\":20, \"layers\":[ { \"data\":[2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 4, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 3, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2], \"height\":20, \"name\":\"Tile Layer 1\", \"opacity\":1, \"type\":\"tilelayer\", \"visible\":true, \"width\":20, \"x\":0, \"y\":0 }, { \"draworder\":\"topdown\", \"height\":0, \"name\":\"objects\", \"objects\":[ { \"gid\":5, \"height\":16, \"id\":43, \"name\":\"button 1\", \"properties\": { \"color\":\"1\", \"group\":\"1\" }, \"propertytypes\": { \"color\":\"string\", \"group\":\"string\" }, \"rotation\":0, \"type\":\"button\", \"visible\":true, \"width\":16, \"x\":160, \"y\":176 }, { \"gid\":7, \"height\":16, \"id\":49, \"name\":\"cube\", \"properties\": { \"color\":\"2\" }, \"propertytypes\": { \"color\":\"string\" }, \"rotation\":0, \"type\":\"cube\", \"visible\":true, \"width\":16, \"x\":208, \"y\":128 }, { \"gid\":5, \"height\":16, \"id\":52, \"name\":\"button 2\", \"properties\": { \"color\":\"2\", \"group\":\"2\" }, \"propertytypes\": { \"color\":\"string\", \"group\":\"string\" }, \"rotation\":0, \"type\":\"button\", \"visible\":true, \"width\":16, \"x\":144, \"y\":176 }, { \"gid\":7, \"height\":16, \"id\":53, \"name\":\"cube\", \"properties\": { \"color\":\"3\" }, \"propertytypes\": { \"color\":\"string\" }, \"rotation\":0, \"type\":\"cube\", \"visible\":true, \"width\":16, \"x\":208, \"y\":224 }, { \"gid\":5, \"height\":16, \"id\":85, \"name\":\"button 3\", \"properties\": { \"color\":\"3\", \"group\":\"3\" }, \"propertytypes\": { \"color\":\"string\", \"group\":\"string\" }, \"rotation\":0, \"type\":\"button\", \"visible\":true, \"width\":16, \"x\":144, \"y\":160 }, { \"gid\":7, \"height\":16, \"id\":86, \"name\":\"cube\", \"properties\": { \"color\":\"4\" }, \"propertytypes\": { \"color\":\"string\" }, \"rotation\":0, \"type\":\"cube\", \"visible\":true, \"width\":16, \"x\":112, \"y\":224 }, { \"gid\":6, \"height\":16, \"id\":94, \"name\":\"wall 1\", \"properties\": { \"group\":\"1\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":256, \"y\":64 }, { \"gid\":6, \"height\":16, \"id\":95, \"name\":\"wall 1\", \"properties\": { \"group\":\"1\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":272, \"y\":64 }, { \"gid\":6, \"height\":16, \"id\":96, \"name\":\"wall 1\", \"properties\": { \"group\":\"1\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":256, \"y\":48 }, { \"gid\":6, \"height\":16, \"id\":99, \"name\":\"wall 2\", \"properties\": { \"group\":\"2\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":272, \"y\":80 }, { \"gid\":6, \"height\":16, \"id\":100, \"name\":\"wall 2\", \"properties\": { \"group\":\"2\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":256, \"y\":80 }, { \"gid\":6, \"height\":16, \"id\":101, \"name\":\"wall 2\", \"properties\": { \"group\":\"2\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":240, \"y\":80 }, { \"gid\":6, \"height\":16, \"id\":102, \"name\":\"wall 2\", \"properties\": { \"group\":\"2\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":240, \"y\":64 }, { \"gid\":6, \"height\":16, \"id\":103, \"name\":\"wall 2\", \"properties\": { \"group\":\"2\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":240, \"y\":48 }, { \"gid\":6, \"height\":16, \"id\":114, \"name\":\"wall 4\", \"properties\": { \"group\":\"4\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":112, \"y\":112 }, { \"gid\":6, \"height\":16, \"id\":116, \"name\":\"wall 4\", \"properties\": { \"group\":\"4\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":112, \"y\":144 }, { \"gid\":5, \"height\":16, \"id\":117, \"name\":\"button 4\", \"properties\": { \"color\":\"4\", \"group\":\"4\" }, \"propertytypes\": { \"color\":\"string\", \"group\":\"string\" }, \"rotation\":0, \"type\":\"button\", \"visible\":true, \"width\":16, \"x\":160, \"y\":160 }, { \"gid\":7, \"height\":16, \"id\":118, \"name\":\"cube\", \"properties\": { \"color\":\"1\" }, \"propertytypes\": { \"color\":\"string\" }, \"rotation\":0, \"type\":\"cube\", \"visible\":true, \"width\":16, \"x\":112, \"y\":128 }, { \"gid\":6, \"height\":16, \"id\":119, \"name\":\"wall 3\", \"properties\": { \"group\":\"3\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":208, \"y\":112 }, { \"gid\":6, \"height\":16, \"id\":120, \"name\":\"wall 3\", \"properties\": { \"group\":\"3\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":192, \"y\":128 }, { \"gid\":6, \"height\":16, \"id\":121, \"name\":\"wall 3\", \"properties\": { \"group\":\"3\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":224, \"y\":128 }, { \"gid\":6, \"height\":16, \"id\":122, \"name\":\"wall 3\", \"properties\": { \"group\":\"3\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":208, \"y\":144 }, { \"gid\":6, \"height\":16, \"id\":123, \"name\":\"wall 4\", \"properties\": { \"group\":\"4\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":96, \"y\":128 }, { \"gid\":6, \"height\":16, \"id\":124, \"name\":\"wall 4\", \"properties\": { \"group\":\"4\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":128, \"y\":128 }], \"opacity\":1, \"type\":\"objectgroup\", \"visible\":true, \"width\":0, \"x\":0, \"y\":0 }], \"nextobjectid\":125, \"orientation\":\"orthogonal\", \"renderorder\":\"right-down\", \"tileheight\":16, \"tilesets\":[ { \"columns\":4, \"firstgid\":1, \"image\":\"../Assets/tiled/tilemap.png\", \"imageheight\":64, \"imagewidth\":64, \"margin\":0, \"name\":\"tilemap\", \"spacing\":0, \"tilecount\":16, \"tileheight\":16, \"tileproperties\": { \"4\": { \"color\":\"1\", \"group\":\"1\" }, \"5\": { \"group\":\"1\", \"inverted\":false }, \"6\": { \"color\":\"1\" } }, \"tilepropertytypes\": { \"4\": { \"color\":\"string\", \"group\":\"string\" }, \"5\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"6\": { \"color\":\"string\" } }, \"tilewidth\":16 }], \"tilewidth\":16, \"version\":1, \"width\":20 }");
		filesData.Add ("level3.json","{ \"height\":20, \"layers\":[ { \"data\":[2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 2, 4, 2, 1, 2, 2, 2, 2, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 2, 2, 2, 2, 2, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2], \"height\":20, \"name\":\"Tile Layer 1\", \"opacity\":1, \"type\":\"tilelayer\", \"visible\":true, \"width\":20, \"x\":0, \"y\":0 }, { \"draworder\":\"topdown\", \"height\":0, \"name\":\"objects\", \"objects\":[ { \"gid\":5, \"height\":16, \"id\":43, \"name\":\"button 1\", \"properties\": { \"color\":\"1\", \"group\":\"1\" }, \"propertytypes\": { \"color\":\"string\", \"group\":\"string\" }, \"rotation\":0, \"type\":\"button\", \"visible\":true, \"width\":16, \"x\":128, \"y\":96 }, { \"gid\":7, \"height\":16, \"id\":49, \"name\":\"cube\", \"properties\": { \"color\":\"2\" }, \"propertytypes\": { \"color\":\"string\" }, \"rotation\":0, \"type\":\"cube\", \"visible\":true, \"width\":16, \"x\":48, \"y\":144 }, { \"gid\":5, \"height\":16, \"id\":52, \"name\":\"button 2\", \"properties\": { \"color\":\"2\", \"group\":\"2\" }, \"propertytypes\": { \"color\":\"string\", \"group\":\"string\" }, \"rotation\":0, \"type\":\"button\", \"visible\":true, \"width\":16, \"x\":80, \"y\":288 }, { \"gid\":7, \"height\":16, \"id\":53, \"name\":\"cube\", \"properties\": { \"color\":\"3\" }, \"propertytypes\": { \"color\":\"string\" }, \"rotation\":0, \"type\":\"cube\", \"visible\":true, \"width\":16, \"x\":128, \"y\":240 }, { \"gid\":5, \"height\":16, \"id\":85, \"name\":\"button 3\", \"properties\": { \"color\":\"3\", \"group\":\"3\" }, \"propertytypes\": { \"color\":\"string\", \"group\":\"string\" }, \"rotation\":0, \"type\":\"button\", \"visible\":true, \"width\":16, \"x\":272, \"y\":288 }, { \"gid\":6, \"height\":16, \"id\":94, \"name\":\"wall 1\", \"properties\": { \"group\":\"1\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":48, \"y\":128 }, { \"gid\":6, \"height\":16, \"id\":95, \"name\":\"wall 1\", \"properties\": { \"group\":\"1\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":64, \"y\":128 }, { \"gid\":6, \"height\":16, \"id\":96, \"name\":\"wall 1\", \"properties\": { \"group\":\"1\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":80, \"y\":128 }, { \"gid\":6, \"height\":16, \"id\":99, \"name\":\"wall 2\", \"properties\": { \"group\":\"2\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":96, \"y\":288 }, { \"gid\":6, \"height\":16, \"id\":100, \"name\":\"wall 2\", \"properties\": { \"group\":\"2\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":96, \"y\":272 }, { \"gid\":6, \"height\":16, \"id\":101, \"name\":\"wall 2\", \"properties\": { \"group\":\"2\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":96, \"y\":256 }, { \"gid\":6, \"height\":16, \"id\":102, \"name\":\"wall 2\", \"properties\": { \"group\":\"2\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":96, \"y\":240 }, { \"gid\":6, \"height\":16, \"id\":103, \"name\":\"wall 2\", \"properties\": { \"group\":\"2\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":96, \"y\":224 }, { \"gid\":7, \"height\":16, \"id\":118, \"name\":\"cube\", \"properties\": { \"color\":\"1\" }, \"propertytypes\": { \"color\":\"string\" }, \"rotation\":0, \"type\":\"cube\", \"visible\":true, \"width\":16, \"x\":160, \"y\":64 }, { \"gid\":6, \"height\":16, \"id\":119, \"name\":\"wall 3\", \"properties\": { \"group\":\"3\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":256, \"y\":208 }, { \"gid\":6, \"height\":16, \"id\":120, \"name\":\"wall 3\", \"properties\": { \"group\":\"3\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":240, \"y\":208 }, { \"gid\":6, \"height\":16, \"id\":121, \"name\":\"wall 3\", \"properties\": { \"group\":\"3\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":224, \"y\":208 }, { \"gid\":6, \"height\":16, \"id\":122, \"name\":\"wall 3\", \"properties\": { \"group\":\"3\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":208, \"y\":208 }, { \"gid\":6, \"height\":16, \"id\":125, \"name\":\"wall 1\", \"properties\": { \"group\":\"1\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":32, \"y\":128 }, { \"gid\":6, \"height\":16, \"id\":126, \"name\":\"wall 3\", \"properties\": { \"group\":\"3\", \"inverted\":false }, \"propertytypes\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"rotation\":0, \"type\":\"wall\", \"visible\":true, \"width\":16, \"x\":272, \"y\":208 }], \"opacity\":1, \"type\":\"objectgroup\", \"visible\":true, \"width\":0, \"x\":0, \"y\":0 }], \"nextobjectid\":127, \"orientation\":\"orthogonal\", \"renderorder\":\"right-down\", \"tileheight\":16, \"tilesets\":[ { \"columns\":4, \"firstgid\":1, \"image\":\"../Assets/tiled/tilemap.png\", \"imageheight\":64, \"imagewidth\":64, \"margin\":0, \"name\":\"tilemap\", \"spacing\":0, \"tilecount\":16, \"tileheight\":16, \"tileproperties\": { \"4\": { \"color\":\"1\", \"group\":\"1\" }, \"5\": { \"group\":\"1\", \"inverted\":false }, \"6\": { \"color\":\"1\" } }, \"tilepropertytypes\": { \"4\": { \"color\":\"string\", \"group\":\"string\" }, \"5\": { \"group\":\"string\", \"inverted\":\"bool\" }, \"6\": { \"color\":\"string\" } }, \"tilewidth\":16 }], \"tilewidth\":16, \"version\":1, \"width\":20 }");
	}

	public static void loadMap(string path) {
		string fileData = filesData[path];
		//string fileData = readFile ("maps/"+path);
		if (fileData != null) { 
			List<Vector4> mapGroups = new List<Vector4>();
			JSONObject json = new JSONObject (fileData);
			JSONObject layers = json.list[json.keys.IndexOf("layers")];
			int size = (int)json.list [json.keys.IndexOf ("height")].n;
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
					JSONObject properties = i.list [i.keys.IndexOf ("properties")];
					output [((int)i.list [i.keys.IndexOf ("y")].n / 16)-1, ((int)i.list [i.keys.IndexOf ("x")].n / 16)] = (properties.list [properties.keys.IndexOf ("inverted")].b)?1:2;
					mapGroups.Add (new Vector4(int.Parse(properties.list[properties.keys.IndexOf ("group")].str), ((int)i.list [i.keys.IndexOf ("x")].n / 16),size - ((int)i.list [i.keys.IndexOf ("y")].n / 16),(properties.list [properties.keys.IndexOf ("inverted")].b)?1:0));
				}else if (i.list [i.keys.IndexOf ("type")].str == "cube") {
					JSONObject properties = i.list [i.keys.IndexOf ("properties")];
					output [((int)i.list [i.keys.IndexOf ("y")].n / 16)-1, ((int)i.list [i.keys.IndexOf ("x")].n / 16)] = 100+int.Parse(properties.list[properties.keys.IndexOf ("color")].str);
				}else if (i.list [i.keys.IndexOf ("type")].str == "button") {
					JSONObject properties = i.list [i.keys.IndexOf ("properties")];
					output [((int)i.list [i.keys.IndexOf ("y")].n / 16)-1, ((int)i.list [i.keys.IndexOf ("x")].n / 16)] = 110+int.Parse(properties.list[properties.keys.IndexOf ("color")].str);
					mapGroups.Add (new Vector4(int.Parse(properties.list[properties.keys.IndexOf ("group")].str), ((int)i.list [i.keys.IndexOf ("x")].n / 16),size-((int)i.list [i.keys.IndexOf ("y")].n / 16),2));
				}
			}
			maps.Add(path, output);
			groups.Add (path, mapGroups);
		}
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
