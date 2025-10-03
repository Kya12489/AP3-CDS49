import 'dart:async';

import 'package:flutter/material.dart';

class TimerLabel extends StatefulWidget {
  final int duration;
  final VoidCallback onEnded;
  const TimerLabel({super.key,required this.duration,required this.onEnded});

  @override
  State<TimerLabel> createState() => _TimerState();
}

class _TimerState extends State<TimerLabel> {
  Timer? timer;
  int currentTime=0;
  @override
  void initState() {
    super.initState();
    currentTime = widget.duration;
    timer = Timer.periodic(
      Duration(seconds: 1),
      (t) {
        setState(() {
          currentTime--;
          
        });
        if (currentTime == 0) {
          t.cancel();
          widget.onEnded();
        }
        
      },
    );
  }
  @override
  void dispose(){
    timer?.cancel();
    super.dispose();
  }
  @override
  Widget build(BuildContext context) {
    return Row(
      children: [
        Icon(Icons.timer),
        Text("$currentTime")
      ],
    );
  }
}