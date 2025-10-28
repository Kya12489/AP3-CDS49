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
    // Se met à jour quand les props changent
    if (widget.scores != oldWidget.scores) {
      setState(() {});
    }
  }

  @override
  Widget build(BuildContext context) {
    final scores = widget.scores ?? [];

    return scores.isEmpty
        ? Center(child: Text('Aucun score disponible'))
        : ListView.builder(
            itemCount: scores.length,
            itemBuilder: (context, index) {
              final score = scores[index];
              return Card(
                margin: EdgeInsets.all(8),
                child: ListTile(
                  title: Text(
                    widget.scale == 0
                        ? 'Score: ${score.getScore()} / ${score.getNbQuestions()}'
                        : 'Score: ${score.getNoteOn(widget.scale)} / ${widget.scale}',
                  ),
                  subtitle: Text(score.getDateFormatted()),
                  trailing: Text(
                    "${score.getScore()}/${score.getNbQuestions()}",
                  ),
                ),
              );
            },
          );
  }
}
