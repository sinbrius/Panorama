

document.addEventListener("DOMContentLoaded", function () {
  //submenu açma kapama
  const submenuToggles = document.querySelectorAll(".submenu-toggle"); //class adında submenutoggle olanları atar
  const sidebar = document.getElementById("sidebar"); //sidebarı alır

  submenuToggles.forEach((toggle) => {
    //her submenu için sırasıyla
    toggle.addEventListener("click", function (e) {
      //click olayı gerçekleşince
      if (sidebar.classList.contains("collapsed")) {
        //sidebar kaaplıysa
        // Sidebar kapalıysa submenu açma
        e.preventDefault(); //e.preventDefault() tıklamanın normalde yapacağı işlemi engeller
        //  (örneğin linkin sayfa yenilemesini veya başka bir şeyi)
        return;
      }

      e.preventDefault(); // Varsayılan link davranışını engelle (sayfa yenileme gibi)

      const submenu = this.nextElementSibling; // Tıklanan elemanın hemen sonraki kardeşini al (genelde <ul class="submenu">)

      if (submenu && submenu.classList.contains("submenu")) {
        // Eğer bu eleman gerçekten bir submenu ise
        submenu.classList.toggle("open"); // "open" sınıfını ekle veya kaldır (görünürlük kontrolü)
      }
    });
  });
});

function toggleSidebar() {
  const sidebar = document.getElementById("sidebar");
  const body = document.body;

  sidebar.classList.toggle("collapsed");

  // Body'e class ekle, böylece CSS üzerinden diğer alanlara yansır
  if (sidebar.classList.contains("collapsed")) {
    body.classList.add("sidebar-collapsed");
  } else {
    body.classList.remove("sidebar-collapsed");
  }
}




   document.getElementById("fileInput").addEventListener("input", function () {
        const url = this.value;
        const extensionMatch = url.match(/\.([a-zA-Z0-9]+)(\?.*)?$/);

        if (extensionMatch) {
            const extension = extensionMatch[1];
            document.getElementById("fileTypeInput").value = "." + extension;
        } else {
            document.getElementById("fileTypeInput").value = "";
        }
    });
