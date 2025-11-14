import 'package:flutter/foundation.dart';

class Score {
  final int idEleve;
  final DateTime dateResultat;
  final int scoreObtenu;
  final int nbQuestions;
  Score({
    required this.dateResultat,
    required this.scoreObtenu,
    required this.nbQuestions,
    this.idEleve = 0,
  });

  String getDateFormatted() {
    return "${dateResultat.day.toString().padLeft(2, '0')}/"
        "${dateResultat.month.toString().padLeft(2, '0')}/"
        "${dateResultat.year} "
        "${dateResultat.hour.toString().padLeft(2, '0')}h";
  }

  int getNoteOn(int scale) {
    return (scoreObtenu * scale) ~/ nbQuestions;
  }

  int getScore() {
    return scoreObtenu;
  }

  int getNbQuestions() {
    return nbQuestions;
  }

  factory Score.fromJson(Map<String, dynamic> json) {
    return Score(
      dateResultat: DateTime.parse(json["dateresultat"]),
      scoreObtenu: json["score"],
      nbQuestions: json["nbquestions"],
      idEleve: json["ideleve"],
    );
  }
}
