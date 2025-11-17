import 'dart:convert';

import 'package:mobil_cds49/models/score.dart';
import 'package:mobil_cds49/models/usr.dart';
import 'package:mobil_cds49/services/api/gestionUsr/usr_api.dart';
import 'package:sqflite/sqflite.dart';
import 'package:path/path.dart';

class ScoreBDD {
  static final ScoreBDD instance = ScoreBDD._init();

  static Database? _database;

  ScoreBDD._init();

  Future<Database> get database async {
    if (_database != null) return _database!;

    _database = await _initDB('score.db');
    return _database!;
  }

  Future<Database> _initDB(String filePath) async {
    final dbPath = await getDatabasesPath();
    final path = join(dbPath, filePath);

    return await openDatabase(path, version: 1, onCreate: _createDB);
  }

  Future _createDB(Database db, int version) async {
    await db.execute('''
      CREATE TABLE scores (
        id INTEGER PRIMARY KEY AUTOINCREMENT,
        idEleve INTEGER,
        dateResultat TEXT NOT NULL,
        scoreObtenu INTEGER NOT NULL,
        nbQuestions INTEGER NOT NULL,
        UNIQUE(idEleve, dateResultat, scoreObtenu, nbQuestions)
      )
    ''');
  }

  Future<void> insertScore(Score score) async {
    print(score.toString());
    final db = await instance.database;
    User? Eleve = await UsrApi.infoUser();
    await db.insert('scores', {
      'dateResultat': score.dateResultat.toIso8601String(),
      'scoreObtenu': score.scoreObtenu,
      'nbQuestions': score.nbQuestions,
      'idEleve': Eleve?.ideleve,
    });
  }

  static Future<void> insertListScore(List<Score> listScore) async {
    final db = await instance.database;
    User? Eleve = await UsrApi.infoUser();

    Batch batch = db.batch();

    for (Score score in listScore) {
      batch.insert('scores', {
        'ideleve': Eleve?.ideleve,
        'dateresultat': score.dateResultat.toIso8601String(),
        'scoreObtenu': score.scoreObtenu,
        'nbquestions': score.nbQuestions,
      }, conflictAlgorithm: ConflictAlgorithm.ignore);
    }

    await batch.commit(noResult: true);
  }

  Future<void> deleteAllScores() async {
    final db = await instance.database;
    User? Eleve = await UsrApi.infoUser();
    await db.delete(
      'scores',
      where: "idEleve = ?",
      whereArgs: [Eleve?.ideleve],
    );
  }

  Future<List<Score>> fetchAllScores() async {
    final db = await instance.database;
    User? Eleve = await UsrApi.infoUser();
    final result = await db.query(
      'scores',
      where: "idEleve = ?",
      whereArgs: [Eleve?.ideleve],
      orderBy: 'dateResultat DESC',
    );

    return result
        .map(
          (json) => Score(
            dateResultat: DateTime.parse(json['dateResultat'] as String),
            scoreObtenu: json['scoreObtenu'] as int,
            nbQuestions: json['nbQuestions'] as int,
            idEleve: Eleve?.ideleve ?? 0,
          ),
        )
        .toList();
  }

  Future<List<Score>> getTop3(DateTime start, DateTime end) async {
    final db = await instance.database;
    User? Eleve = await UsrApi.infoUser();
    final result = await db.rawQuery(
      '''
  SELECT * FROM scores
  WHERE dateResultat BETWEEN ? AND ? AND idEleve = ?
  ORDER BY (scoreObtenu * 40.0 / nbQuestions) DESC
  LIMIT 3
''',
      [start.toIso8601String(), end.toIso8601String(), Eleve?.ideleve],
    );

    return result
        .map(
          (json) => Score(
            dateResultat: DateTime.parse(json["dateResultat"] as String),
            scoreObtenu: json["scoreObtenu"] as int,
            nbQuestions: json["nbQuestions"] as int,
            idEleve: Eleve?.ideleve ?? 0,
          ),
        )
        .toList();
  }

  Future<List<Score>> getScoreOfPeriod(DateTime start, DateTime end) async {
    final db = await instance.database;
    User? Eleve = await UsrApi.infoUser();
    final result = await db.query(
      "scores",
      where: "dateResultat BETWEEN ? AND ? AND idEleve = ?",
      whereArgs: [
        start.toIso8601String(),
        end.toIso8601String(),
        Eleve?.ideleve,
      ],
      orderBy: 'dateResultat DESC',
    );

    return result
        .map(
          (json) => Score(
            dateResultat: DateTime.parse(json['dateResultat'] as String),
            scoreObtenu: json['scoreObtenu'] as int,
            idEleve: Eleve?.ideleve ?? 0,
            nbQuestions: json['nbQuestions'] as int,
          ),
        )
        .toList();
  }

  Future close() async {
    final db = await instance.database;

    db.close();
  }
}
