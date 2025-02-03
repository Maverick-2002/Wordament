mergeInto(LibraryManager.library, {
  FetchWordsFromFirebase: function() {
    if (!firebase.apps.length) {
      firebase.initializeApp({
        apiKey: "AIzaSyCu_oqDfhyVmQ9HymU2cuaPPZD2Oi-imPs",
  authDomain: "wordament-16b5a.firebaseapp.com",
  projectId: "wordament-16b5a",
  storageBucket: "wordament-16b5a.firebasestorage.app",
  messagingSenderId: "828815934558",
  appId: "1:828815934558:web:66dab8993514321e4fa0cf"
      });
    }

    var db = firebase.firestore();

    db.collection("wordlist").doc("Testing").get().then((doc) => {
      if (doc.exists) {
        var wordsArray = doc.data().words; // Fetch words
        SendMessage('GameManager', 'OnWordsReceived', wordsArray.join(",")); // Send to Unity
        console.log('firebase active');
      } else {
        console.log("No such document!");
      }
    }).catch((error) => {
      console.error("Error fetching words:", error);
    });
  }
});
