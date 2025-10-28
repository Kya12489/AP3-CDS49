import 'package:flutter/material.dart';
import 'package:mobil_cds49/models/score.dart';

class ScoresListview extends StatefulWidget {
  final List<Score>? scores;
  final int scale;
  const ScoresListview({super.key, this.scores, this.scale = 0});

  @override
  _ScoresListviewState createState() => _ScoresListviewState();
}

class _ScoresListviewState extends State<ScoresListview> {
  @override
  void didUpdateWidget(ScoresListview oldWidget) {
    super.didUpdateWidget(oldWidget);
    if (widget.scores != oldWidget.scores) {
      setState(() {});
    }
  }

  // Fonction pour obtenir le rang d'un score parmi les 3 meilleurs
  int? _getRankInTop3(Score score, List<Score> allScores) {
    // Créer une copie triée pour identifier les 3 meilleurs
    List<Score> sortedScores = List.from(allScores);
    sortedScores.sort((a, b) {
      double percentA = a.getScore() / a.getNbQuestions();
      double percentB = b.getScore() / b.getNbQuestions();
      return percentB.compareTo(percentA);
    });

    // Trouver si ce score est dans le top 3
    for (int i = 0; i < 3 && i < sortedScores.length; i++) {
      if (sortedScores[i] == score) {
        return i;
      }
    }
    return null; // Pas dans le top 3
  }

  // Fonction pour obtenir la couleur selon le rang
  Color _getColorForRank(int? rank) {
    if (rank == null) return Colors.white;
    switch (rank) {
      case 0:
        return Colors.amber.shade100; // Or
      case 1:
        return Colors.grey.shade300; // Argent
      case 2:
        return Colors.orange.shade200; // Bronze
      default:
        return Colors.white;
    }
  }

  // Fonction pour obtenir l'icône selon le rang
  Widget? _getIconForRank(int? rank) {
    if (rank == null) return null;
    switch (rank) {
      case 0:
        return Text('🥇', style: TextStyle(fontSize: 24));
      case 1:
        return Text('🥈', style: TextStyle(fontSize: 24));
      case 2:
        return Text('🥉', style: TextStyle(fontSize: 24));
      default:
        return null;
    }
  }

  @override
  Widget build(BuildContext context) {
    final scores = widget.scores ?? [];

    if (scores.isEmpty) {
      return Center(child: Text('Aucun score disponible'));
    }

    return ListView.builder(
      itemCount: scores.length,
      itemBuilder: (context, index) {
        final score = scores[index];
        final rank = _getRankInTop3(score, scores);
        final isTopThree = rank != null;
        final icon = _getIconForRank(rank);

        return Card(
          margin: EdgeInsets.all(8),
          elevation: isTopThree ? 4 : 1,
          color: _getColorForRank(rank),
          child: ListTile(
            leading: icon,
            title: Text(
              widget.scale == 0
                  ? 'Score: ${score.getScore()} / ${score.getNbQuestions()}'
                  : 'Score: ${score.getNoteOn(widget.scale)} / ${widget.scale}',
              style: TextStyle(
                fontWeight: isTopThree ? FontWeight.bold : FontWeight.normal,
                fontSize: isTopThree ? 16 : 14,
              ),
            ),
            subtitle: Text(score.getDateFormatted()),
            trailing: Container(
              padding: EdgeInsets.symmetric(horizontal: 12, vertical: 6),
              decoration: BoxDecoration(
                color: isTopThree ? Colors.white : Colors.grey.shade100,
                borderRadius: BorderRadius.circular(12),
              ),
              child: Text(
                "${score.getScore()}/${score.getNbQuestions()}",
                style: TextStyle(
                  fontWeight: isTopThree ? FontWeight.bold : FontWeight.normal,
                  color: isTopThree ? Colors.black87 : Colors.black54,
                ),
              ),
            ),
          ),
        );
      },
    );
  }
}
