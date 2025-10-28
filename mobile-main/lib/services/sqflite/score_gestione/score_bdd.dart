import 'package:mobil_cds49/models/score.dart';
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
        dateResultat TEXT NOT NULL,
        scoreObtenu INTEGER NOT NULL,
        nbQuestions INTEGER NOT NULL
      )
    ''');
  }

  Future<void> insertScore(Score score) async {
    final db = await instance.database;

    await db.insert('scores', {
      'dateResultat': score.dateResultat.toIso8601String(),
      'scoreObtenu': score.scoreObtenu,
      'nbQuestions': score.nbQuestions,
    });
  }

  Future<List<Score>> fetchAllScores() async {
    final db = await instance.database;

    final result = await db.query('scores', orderBy: 'dateResultat DESC');

    return result
        .map(
          (json) => Score(
            dateResultat: DateTime.parse(json['dateResultat'] as String),
            scoreObtenu: json['scoreObtenu'] as int,
            nbQuestions: json['nbQuestions'] as int,
          ),
        )
        .toList();
  }

  Future<List<Score>> getScoreOfPeriod(DateTime start, DateTime end) async {
    final db = await instance.database;

    final result = await db.query(
      "scores",
      where: "dateResultat BETWEEN ? ABD ?",
      whereArgs: [start.toIso8601String(), end.toIso8601String()],
      orderBy: 'dateResultat DESC',
    );

    return result
        .map(
          (json) => Score(
            dateResultat: DateTime.parse(json['dateResultat'] as String),
            scoreObtenu: json['scoreObtenu'] as int,
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
