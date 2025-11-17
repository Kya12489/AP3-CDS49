class Document {
  final int id;
  final int idEleve;
  final int idType;
  final int idStatut;
  final String lien;

  final String type;
  final String statut;

  Document({
    required this.id,
    required this.idEleve,
    required this.idType,
    required this.idStatut,
    required this.lien,
    this.type = "",
    this.statut = "",
  });

  factory Document.fromJson(Map<String, dynamic> json) {
    return Document(
      id: json['idDoc'],
      idEleve: json['idEleve'],
      idType: json['idType'],
      idStatut: json['idStatut'],
      lien: json['lienDoc'] ?? "",
      type: json['libelleType'] ?? "",
      statut: json['libelleStatut'] ?? "",
    );
  }
}
