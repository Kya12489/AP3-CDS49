class Score {
  final DateTime dateResultat;
  final int scoreObtenu;
  final int nbQuestions;
  Score({
    required this.dateResultat,
    required this.scoreObtenu,
    required this.nbQuestions,
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
}
