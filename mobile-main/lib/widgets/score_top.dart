import 'package:flutter/material.dart';
import 'package:mobil_cds49/models/score.dart';

class scoreTop extends StatelessWidget {
  const scoreTop({super.key});

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Container(
          width: 125,
          height: 125,
          decoration: BoxDecoration(
            shape: BoxShape.circle,
            color: Color.fromRGBO(255, 4, 4, 1),
          ),
          child: Center(child: Text("CERCLE")),
        ),
        Row(
          mainAxisAlignment: MainAxisAlignment.spaceBetween,
          children: [
            Container(
              width: 125,
              height: 125,
              decoration: BoxDecoration(
                shape: BoxShape.circle,
                color: Color.fromRGBO(255, 4, 4, 1),
              ),
              child: Center(child: Text("CERCLE")),
            ),
            Container(
              width: 125,
              height: 125,
              decoration: BoxDecoration(
                shape: BoxShape.circle,
                color: Color.fromRGBO(255, 4, 4, 1),
              ),
              child: Center(child: Text("CERCLE")),
            ),
          ],
        ),
      ],
    );
  }
}
