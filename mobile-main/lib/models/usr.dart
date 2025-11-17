class User {
  final int ideleve;
  final String? nomeleve;
  final String? prenomeleve;
  final String? emailEleve;
  final String? dateNEleve;

  User({
    required this.ideleve,
    required this.nomeleve,
    required this.prenomeleve,
    required this.emailEleve,
    required this.dateNEleve,
  });

  factory User.fromJson(Map<String, dynamic> json) {
    return User(
      ideleve: json['ideleve'],
      nomeleve: json['nomeleve'],
      prenomeleve: json['prenomeleve'],
      emailEleve: json['emaileleve'],
      dateNEleve: json['datenaissanceeleve'],
    );
  }
}
